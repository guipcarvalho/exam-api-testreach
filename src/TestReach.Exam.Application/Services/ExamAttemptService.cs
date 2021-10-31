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

namespace TestReach.Exam.Application.Services
{
    public class ExamAttemptService : IExamAttemptService
    {
        private readonly Func<string, IExamAttemptFileParser> _fileParserFactory;

        public ExamAttemptService(Func<string, IExamAttemptFileParser> fileParserFactory)
        {
            _fileParserFactory = fileParserFactory;
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
