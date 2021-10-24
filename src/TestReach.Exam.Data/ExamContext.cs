using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Core.Data;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Data
{
    public class ExamContext : DbContext, IUnitOfWork
    {
        public ExamContext(DbContextOptions<ExamContext> options) : base(options) { }

        public DbSet<Domain.Entities.Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }

        public async Task<bool> Commit(CancellationToken cancellationToken) => await base.SaveChangesAsync(cancellationToken) > 0;
    }
}
