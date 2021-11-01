using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestReach.Exam.Core.Data;
using TestReach.Exam.Data.Contexts;
using TestReach.Exam.Domain.Dtos;
using TestReach.Exam.Domain.Entities;
using TestReach.Exam.Domain.Repositories;
using System.Linq;
using System;

namespace TestReach.Exam.Data.Repositories
{
    public sealed class ExamAttemptRepository : BaseRepository<ExamAttempt>, IExamAttemptRepository
    {
        private readonly IDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ExamAttemptRepository(IDbContext context)
        {
            _context = context;
        }

        public override DbSet<ExamAttempt> GetDbSet() => _context.ExamAttempts;

        public Task<List<ExamAttemptFlatDto>> GetByExamIdAndCandidate(string examId, string candidateEmail, CancellationToken cancellationToken)
        {
            var query =  from examAttempt in _context.ExamAttempts 
            join answer in _context.Answers on examAttempt.Id equals answer.ExamAttemptId
            where examAttempt.ExamId == examId && candidateEmail == examAttempt.Candidate.Email
            select new ExamAttemptFlatDto
            {
                ExamId = examAttempt.ExamId,
                CandidateEmail = examAttempt.Candidate.Email,
                CandidateName = examAttempt.Candidate.Name,
                ExamDate = examAttempt.AttemptDate,
                QuestionNumber = answer.QuestionNumber,
                Answer = answer.ChosenOption
            };

            return query.ToListAsync(cancellationToken);
        }
            
        public void Dispose() => _context?.Dispose();
    }
}
