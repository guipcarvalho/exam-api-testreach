using FluentValidation.Results;
using System.Collections.Generic;
using TestReach.Exam.Core.Messages;
using TestReach.Exam.Domain.Commands.Validations;

namespace TestReach.Exam.Domain.Commands
{
    public class BatchCreateExamAttemptCommand : Command
    {
        public IEnumerable<CreateExamAttemptCommand> Commands { get; set; }

        public override ValidationResult Validate() => new BatchCreateExamAttemptCommandValidation().Validate(this);
    }
}
