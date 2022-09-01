using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Subject_s.DeleteSubject
{
    public class DeleteSubjectCommandValidator : AbstractValidator<DeleteSubjectCommand>
    {
        public DeleteSubjectCommandValidator()
        {
            RuleFor(x => x.SubjectId).NotEqual(Guid.Empty);
        }
    }
}
