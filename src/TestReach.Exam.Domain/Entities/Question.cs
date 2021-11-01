using System;

namespace TestReach.Exam.Domain.Entities
{
    public class Question
    {
        public Question()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public int QuestionNumber { get; set; }
        public char CorrectAnswer { get; set; }
        public string ExamId { get; set; }

        public virtual Exam Exam { get; set; }
    }
}