using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Application.Helpers.Contracts;
using TestReach.Exam.Application.Services.Contracts;
using TestReach.Exam.Core.Bus;
using TestReach.Exam.Core.Messages;
using TestReach.Exam.Domain.Commands;
using TestReach.Exam.Domain.Repositories;

namespace TestReach.Exam.Application.Services
{
    public class ExamAttemptService : IExamAttemptService
    {
        private readonly Func<string, IExamAttemptFileParser> _fileParserFactory;
        private readonly IExamAttemptRepository _repository;
        private readonly IMediatorHandler _mediator;

        public ExamAttemptService(Func<string, IExamAttemptFileParser> fileParserFactory, IExamAttemptRepository repository, IMediatorHandler mediator)
        {
            _fileParserFactory = fileParserFactory;
            _repository = repository;
            _mediator = mediator;
        }

        public async Task<GenericResult> ExportExamAttemptToFile(string examId, string candidateEmail, string fileType, CancellationToken cancellationToken)
        {
            var examAttempts = await _repository.GetByExamIdAndCandidate(examId, candidateEmail, cancellationToken);

            if (!examAttempts.Any())
                return new GenericResult(Core.Enums.Response.NotFound, $"Exam attempt not found for exam {examId} and candidate {candidateEmail}");

            try
            {
                using var memoryStream = new MemoryStream();
                await _fileParserFactory(fileType).ParseToFile(memoryStream, examAttempts);

                return new GenericResult(Core.Enums.Response.Success, memoryStream.ToArray());
            }
            catch (NotSupportedException ex)
            {
                return new GenericResult(Core.Enums.Response.Invalid, ex.Message);
            }
        }

        public async Task<GenericResult> ImportAttempts(Stream fileStream, string fileType, CancellationToken cancellationToken)
        {
            var command = new BatchCreateExamAttemptCommand();

            try
            {
                command.Commands = await _fileParserFactory(fileType).GetExamAttemps(fileStream);
            }
            catch (NotSupportedException ex)
            {
                return new GenericResult(Core.Enums.Response.Invalid, ex.Message);
            }

            return await _mediator.SendCommand(command, cancellationToken);
        }
    }
}
