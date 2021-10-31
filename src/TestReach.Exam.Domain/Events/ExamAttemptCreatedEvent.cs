using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReach.Exam.Core.Messages;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Domain.Events
{
    public class ExamAttemptCreatedEvent : Event
    {
        public ExamAttempt ExamAttempt { get; set; }
    }
}
