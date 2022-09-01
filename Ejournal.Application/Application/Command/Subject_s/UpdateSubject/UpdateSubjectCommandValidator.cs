using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Subject_s.UpdateSubject
{
    public class UpdateSubjectCommandValidator : AbstractValidator<UpdateSubjectCommand>
    {
        public UpdateSubjectCommandValidator()
        {
            RuleFor(X => X.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
            RuleFor(x => x.DepartmentId).NotEqual(Guid.Empty);
            RuleFor(x => x.SubjectId).NotEqual(Guid.Empty);
        }
    }
}
