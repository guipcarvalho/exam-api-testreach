using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestReach.Exam.Domain.Commands.Validations
{
    public class BatchCreateExamAttemptCommandValidation : AbstractValidator<BatchCreateExamAttemptCommand>
    {
        public BatchCreateExamAttemptCommandValidation()
        {
            RuleFor(x => x.Commands)
                .NotEmpty().WithMessage("You should provide at leat one creation command");
        }
    }
}
