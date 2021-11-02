using System;
using System.Collections.Generic;
using System.Linq;
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
        public decimal Score { get; set; }

        public virtual Candidate Candidate { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual List<Answer> Answers { get; set; }

        public virtual decimal CalculateScore()
        {
            decimal total = Exam.Questions.Count;

            var questionDictionary = Exam.Questions.ToDictionary(x => x.QuestionNumber);

            decimal correct = 0;
            foreach (var answer in Answers)
            {
                if (questionDictionary.ContainsKey(answer.QuestionNumber) && questionDictionary[answer.QuestionNumber].CorrectAnswer == answer.ChosenOption)
                    correct++;
            }

            return Score = (correct / total) * 100m;
        }
    }
}
