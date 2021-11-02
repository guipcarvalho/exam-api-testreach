using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Core.Data;
using TestReach.Exam.Domain.Dtos;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Domain.Repositories
{
    public interface IExamAttemptRepository : IRepository<ExamAttempt>
    {
        Task<List<ExamAttemptDto>> GetByExamIdAndCandidate(string examId, string candidateEmail, CancellationToken cancellationToken);
    }
}
