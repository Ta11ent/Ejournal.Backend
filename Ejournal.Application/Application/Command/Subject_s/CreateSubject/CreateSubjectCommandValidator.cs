using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Subject_s.CreateSubject
{
    public class CreateSubjectCommandValidator : AbstractValidator<CreateSubjectCommand>
    {
        public CreateSubjectCommandValidator()
        {
            RuleFor(X => X.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
            RuleFor(x => x.DepartmentId).NotEqual(Guid.Empty);
        }
    }
}
