using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using TestReach.Exam.Core.Data;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Data.Contexts
{
    public interface IDbContext: IUnitOfWork, IDisposable
    {
        public DatabaseFacade Database { get; }

        public DbSet<Domain.Entities.Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<ExamAttempt> ExamAttempts { get; set; }
        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}
