using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Core.Data;

namespace TestReach.Exam.Domain.Repositories
{
    public interface IExamRepository : IRepository<Domain.Entities.Exam>
    {
        Task<Dictionary<string, Domain.Entities.Exam>> GetExistingExams(IEnumerable<string> examIds, CancellationToken cancellationToken);
    }
}
