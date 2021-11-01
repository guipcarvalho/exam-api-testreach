using FluentValidation;
using TestReach.Exam.Domain.Entities;

namespace TestReach.Exam.Domain.Commands.Validations
{
    public class CreateExamAttemptCommandValidation : AbstractValidator<CreateExamAttemptCommand>
    {
        public CreateExamAttemptCommandValidation()
        {
            RuleFor(x => x.ExamId)
                .NotEmpty().WithMessage("Exam Id should not be empty");

            RuleFor(x => x.ExamDate)
                .NotEmpty().WithMessage("Exam Date should not be empty");

            RuleFor(x => x.CandidateName)
                .NotEmpty().WithMessage("Candidate name should not be empty");

            RuleFor(x => x.CandidateEmail)
                .NotEmpty().WithMessage("Candidate email should not be empty");

            RuleFor(x => x.Answers)
                .NotEmpty().WithMessage("Exam attempt should have at least an answer");

            RuleForEach(x => x.Answers).SetValidator(new CreateExamAttemptCommandAnswerValidation());
        }

        public class CreateExamAttemptCommandAnswerValidation : AbstractValidator<Answer>
        {
            public CreateExamAttemptCommandAnswerValidation()
            {
                RuleFor(x => x.ChosenOption)
                    .NotEmpty().WithMessage("Answer chosen option should not be empty");

                RuleFor(x => x.QuestionNumber)
                    .NotEmpty().WithMessage("Answer question number should not be empty");
            }
        }
    }
}
