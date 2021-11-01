using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Core.Bus;
using TestReach.Exam.Core.Messages;
using TestReach.Exam.Domain.Commands;
using TestReach.Exam.Domain.Entities;
using TestReach.Exam.Domain.Events;
using TestReach.Exam.Domain.Repositories;

namespace TestReach.Exam.Domain.CommandHandlers
{
    public class ExamAttemptCommandHandler : CommandHandler,
        IRequestHandler<BatchCreateExamAttemptCommand, GenericResult>
    {
        private readonly IMediatorHandler _mediator;
        private readonly IExamAttemptRepository _examAttemptRepository;
        private readonly IExamRepository _examRepository;
        private readonly IMapper _mapper;

        public ExamAttemptCommandHandler(IMediatorHandler mediator, IExamAttemptRepository examAttemptRepository, IExamRepository examRepository, IMapper mapper)
        {
            _mediator = mediator;
            _examAttemptRepository = examAttemptRepository;
            _examRepository = examRepository;
            _mapper = mapper;
        }

        public async Task<GenericResult> Handle(BatchCreateExamAttemptCommand request, CancellationToken cancellationToken)
        {
            var inserted = new List<ExamAttempt>();

            if(request.IsValid())
            {
                var existingExams = await _examRepository.GetExistingExams(request.Commands.Select(x => x.ExamId), cancellationToken);

                foreach (var command in request.Commands)
                {
                    if (!command.IsValid() || !existingExams.ContainsKey(command.ExamId))
                        continue;

                    var examAttempt = _mapper.Map<ExamAttempt>(command);
                    examAttempt.Exam = existingExams[command.ExamId];
                    examAttempt.CalculateScore();

                    _examAttemptRepository.Add(examAttempt);
                    
                    inserted.Add(examAttempt);
                }
            }

            if (inserted.Any())
            {
                await _examAttemptRepository.UnitOfWork.Commit(cancellationToken);
                foreach (var item in inserted)
                {
                    // event published to the memory bus so it can be listened and it could be possible to trigger
                    // different business rules after the success of this one
                    _ = _mediator.PublishEvent(new ExamAttemptCreatedEvent(item));
                }
            }

            return new GenericResult(Core.Enums.Response.Success, inserted.Select(x => new { x.Id, x.ExamId, x.Candidate.Email }));
        }
    }
}
