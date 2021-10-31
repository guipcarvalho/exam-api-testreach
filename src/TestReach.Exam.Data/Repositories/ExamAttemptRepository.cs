using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReach.Exam.Core.Data;
using TestReach.Exam.Data.Contexts;
using TestReach.Exam.Domain.Entities;
using TestReach.Exam.Domain.Repositories;

namespace TestReach.Exam.Data.Repositories
{
    public class ExamAttemptRepository : IExamAttemptRepository
    {
        private readonly IDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ExamAttemptRepository(IDbContext context)
        {
            _context = context;
        }

        public ExamAttempt GetByExamIdAndCandidate(string examId, string candidateEmail)
        {
            return _context.ExamAttempts.AsNoTracking()
                        .Include(x => x.Candidate)
                        .Include(x => x.Answers)
                        .FirstOrDefault(x => x.ExamId == examId && x.Candidate.Email == candidateEmail);
        }

        public void Dispose() => _context?.Dispose();
    }
}
