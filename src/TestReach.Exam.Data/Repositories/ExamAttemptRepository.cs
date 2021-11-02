using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
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
using Microsoft.Data.SqlClient;

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

        public async Task<List<ExamAttemptDto>> GetByExamIdAndCandidate(string examId, string candidateEmail, CancellationToken cancellationToken)
        {
            var resultList = new List<ExamAttemptDto>();
            var connection = _context.Database.GetDbConnection();
            var command = connection.CreateCommand();
            command.CommandText = @"
                SELECT e.ExamId, AverageScore, c.Email, c.Name, e.Score, PercentRank
                FROM ExamAttempts e
                JOIN Candidates c ON c.Id = e.CandidateId
                JOIN (
                    SELECT ExamId, AVG(Score) as AverageScore  FROM ExamAttempts
                    GROUP BY ExamId
                ) AvgScore ON AvgScore.ExamId = e.ExamId
                JOIN (
                    SELECT Id, (cast(PERCENT_RANK() OVER (ORDER BY Score) as decimal(18,2)) * 100.00)  PercentRank  FROM ExamAttempts
                ) PerRank ON PerRank.Id = e.Id
                WHERE e.ExamId = @examId AND c.Email = @candidateEmail
            ";
            command.Parameters.Add(new SqlParameter(nameof(examId), examId));
            command.Parameters.Add(new SqlParameter(nameof(candidateEmail), candidateEmail));

            await connection.OpenAsync(cancellationToken);
            var reader = await command.ExecuteReaderAsync(cancellationToken);

            while(await reader.ReadAsync(cancellationToken))
            {
                resultList.Add(
                    new ExamAttemptDto
                    {
                        ExamId = reader.GetString(0),
                        AverageScore = reader.GetDecimal(1),
                        CandidateEmail = reader.GetString(2),
                        CandidateName = reader.GetString(3),
                        Score = reader.GetDecimal(4),
                        PercentRank = reader.GetDecimal(5)
                    });
            }

            return resultList;
        }
            
        public void Dispose() => _context?.Dispose();
    }
}
