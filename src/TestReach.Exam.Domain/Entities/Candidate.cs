using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestReach.Exam.Core.Data;

namespace TestReach.Exam.Domain.Entities
{
    public class Candidate : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public List<ExamAttempt> ExamAttempts { get; set; }
    }
}
