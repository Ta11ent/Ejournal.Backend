using FluentValidation;
using System;

namespace Ejournal.Application.Ejournal.Command.Department_s.DeleteDepartment
{
    public class DeleteDepartmetCommandValidator : AbstractValidator<DeleteDepartmentCommand>
    {
        public DeleteDepartmetCommandValidator()
        {
            RuleFor(x => x.DepartmentId).NotEqual(Guid.Empty);
        }
    }
}
