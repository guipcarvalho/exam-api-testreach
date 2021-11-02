using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Core.Messages;

namespace TestReach.Exam.Application.Services.Contracts
{
    public interface IExamAttemptService
    {
        Task<GenericResult> ImportAttempts(Stream fileStream, string fileType, CancellationToken cancellationToken);

        Task<GenericResult> ExportExamAttemptToFile(string examId, string candidateEmail, string fileType, CancellationToken cancellationToken);
    }
}
