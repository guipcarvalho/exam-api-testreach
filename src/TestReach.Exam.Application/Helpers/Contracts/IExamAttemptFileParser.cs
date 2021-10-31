using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TestReach.Exam.Application.Dtos;
using TestReach.Exam.Domain.Commands;

namespace TestReach.Exam.Application.Helpers.Contracts
{
    public interface IExamAttemptFileParser
    {
        Task<IEnumerable<CreateExamAttemptCommand>> GetExamAttemps(Stream stream);
        Task ParseToFile(Stream outputStream, IEnumerable<ExamAttemptFlatDto> examAttempts);
    }
}
