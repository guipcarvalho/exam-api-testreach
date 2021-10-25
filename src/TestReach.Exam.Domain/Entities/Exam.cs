using System;
using System.Collections.Generic;
using TestReach.Exam.Core.Data;

namespace TestReach.Exam.Domain.Entities
{
    public class Exam : IEntity
    {
        public Exam()
        {
            CreationDate = DateTime.Now;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }

        public List<Question> Questions { get; set; }
        public List<ExamAttempt> ExamAttempts { get; set; }
    }
}
