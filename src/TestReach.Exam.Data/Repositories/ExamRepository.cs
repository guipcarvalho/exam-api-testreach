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
    public sealed class ExamRepository : BaseRepository<Domain.Entities.Exam>, IExamRepository
    {
        private readonly IDbContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public ExamRepository(IDbContext context)
        {
            _context = context;
        }

        public override DbSet<Domain.Entities.Exam> GetDbSet() => _context.Exams;

        public Task<Dictionary<string, Domain.Entities.Exam>> GetExistingExams(IEnumerable<string> examIds, CancellationToken cancellationToken)
        {
            return _context.Exams.Include(x => x.Questions).Where(x => examIds.Contains(x.Id)).ToDictionaryAsync(x => x.Id, cancellationToken);
        }
            
        public void Dispose() => _context?.Dispose();
    }
}
