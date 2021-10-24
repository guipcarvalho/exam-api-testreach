using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReach.Exam.Core.Data;

namespace TestReach.Exam.Domain.Entities
{
    public class ExamAttempt : IEntity
    {
        public Guid Id { get; set; }
        public DateTime AttemptDate { get; set; }
        public Guid CandidateId { get; set; }

        public Candidate Candidate { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
