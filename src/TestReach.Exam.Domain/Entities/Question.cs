using System;

namespace TestReach.Exam.Domain.Entities
{
    public class Question
    {
        public Guid Id { get; set; }
        public int QuestionNumber { get; set; }
        public char CorrectAnswer { get; set; }
        public string ExamId { get; set; }

        public Exam Exam { get; set; }
    }
}