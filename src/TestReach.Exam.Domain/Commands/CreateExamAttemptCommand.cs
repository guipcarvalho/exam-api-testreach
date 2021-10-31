using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReach.Exam.Core.Messages;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Domain.Commands
{
    public class CreateExamAttemptCommand : Command
    {
        public string ExamId { get; set; }
        public DateTime? ExamDate { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidateName { get; set; }

        public List<Answer> Answers { get; set; }
    }
}
