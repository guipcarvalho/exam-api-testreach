using System;

namespace TestReach.Exam.Domain.Dtos
{
    public class ExamAttemptDto
    {
        public string ExamId { get; set; }
        public decimal AverageScore { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidateName { get; set; }
        public decimal Score { get; set; }
        public decimal PercentRank { get; set; }
    }
}
