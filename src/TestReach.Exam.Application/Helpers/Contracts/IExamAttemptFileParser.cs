using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Domain.Commands;
using TestReach.Exam.Domain.Dtos;

namespace TestReach.Exam.Application.Helpers.Contracts
{
    public interface IExamAttemptFileParser
    {
        Task<IEnumerable<CreateExamAttemptCommand>> GetExamAttemps(Stream stream);
        Task ParseToFile(Stream outputStream, IEnumerable<ExamAttemptDto> examAttempts);
    }
}
