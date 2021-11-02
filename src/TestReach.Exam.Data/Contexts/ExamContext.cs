using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Core.Data;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Data.Contexts
{
    public class ExamContext : DbContext, IDbContext
    {
        public ExamContext(DbContextOptions<ExamContext> options) : base(options) { }

        public DbSet<Domain.Entities.Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ExamAttempt> ExamAttempts { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExamContext).Assembly);
        }

        public async Task<bool> Commit(CancellationToken cancellationToken) => await base.SaveChangesAsync(cancellationToken) > 0;
    }
}
