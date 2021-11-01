using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Application.Helpers.Contracts;
using TestReach.Exam.Application.Services.Contracts;
using TestReach.Exam.Core.Messages;
using TestReach.Exam.Domain.Commands;
using TestReach.Exam.Domain.Repositories;

namespace TestReach.Exam.Application.Services
{
    public class ExamAttemptService : IExamAttemptService
    {
        private readonly Func<string, IExamAttemptFileParser> _fileParserFactory;
        private readonly IExamAttemptRepository _repository;

        public ExamAttemptService(Func<string, IExamAttemptFileParser> fileParserFactory, IExamAttemptRepository repository)
        {
            _fileParserFactory = fileParserFactory;
            _repository = repository;
        }

        public async Task<GenericResult> ExportExamAttemptToFile(Stream outputStream, string examId, string candidateEmail, string fileType, CancellationToken cancellationToken)
        {
            var examAttempt = await _repository.GetByExamIdAndCandidate(examId, candidateEmail, cancellationToken);

            if (!examAttempt.Any())
                return new GenericResult(Core.Enums.Response.NotFound, $"Exam attempt not found for exam {examId} and candidate {candidateEmail}");

            try
            {
                await _fileParserFactory(fileType).ParseToFile(outputStream, examAttempt);
            }
            catch (NotSupportedException ex)
            {
                return new GenericResult(Core.Enums.Response.Invalid, ex.Message);
            }

            return new GenericResult(Core.Enums.Response.Success, "File generated!");
        }

        public async Task<GenericResult> ImportAttempts(Stream fileStream, string fileType, CancellationToken cancellationToken)
        {
            IEnumerable<CreateExamAttemptCommand> commands;

            try
            {
                commands = await _fileParserFactory(fileType).GetExamAttemps(fileStream);
            }
            catch (NotSupportedException ex)
            {
                return new GenericResult(Core.Enums.Response.Invalid, ex.Message);
            }

            return new GenericResult(Core.Enums.Response.Success, "Exam Attempts Imported successfully!");
        }
    }
}
