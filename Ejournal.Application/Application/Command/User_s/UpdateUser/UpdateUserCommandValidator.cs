using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.User_s.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.MiddleName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Birthday).NotNull().LessThan(x => (DateTime.Today.AddYears(-6)));
            RuleFor(x => x.Gender).NotNull();
            RuleFor(x => x.HasAccount).NotNull();
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.Active).NotNull();
        }
    }
}
