using System;
using TestReach.Exam.Core.Data;

namespace TestReach.Exam.Domain.Entities
{
    public class Answer : IEntity
    {
        public Answer()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public Guid ExamAttemptId { get; set; }
        public int QuestionNumber { get; set; }
        public char ChosenOption { get; set; }

        public virtual ExamAttempt ExamAttempt { get; set; }
    }
}