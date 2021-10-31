using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReach.Exam.Application.Dtos
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
