using System;
using System.Collections.Generic;
using TestReach.Exam.Core.Data;

namespace TestReach.Exam.Domain.Entities
{
    public class ExamAttempt : IEntity
    {
        public ExamAttempt()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid CandidateId { get; set; }
        public string ExamId { get; set; }
        public DateTime AttemptDate { get; set; }
        

        public Candidate Candidate { get; set; }
        public Exam Exam { get; set; }
        public List<Answer> Answers { get; set; }
    }
}
