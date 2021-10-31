using FluentValidation.Results;
using MediatR;

namespace TestReach.Exam.Core.Messages
{
    public abstract class Command : IRequest<GenericResult>
    {
        public bool IsValid() => Validate().IsValid;

        public abstract ValidationResult Validate();
    }
}
