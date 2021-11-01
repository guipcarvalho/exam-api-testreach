using System;

namespace TestReach.Exam.Domain.Dtos
{
    public class ExamAttemptFlatDto
    {
        public string ExamId { get; set; }
        public DateTime ExamDate { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidateName { get; set; }
        public int QuestionNumber { get; set; }
        public char Answer { get; set; }
    }
}
