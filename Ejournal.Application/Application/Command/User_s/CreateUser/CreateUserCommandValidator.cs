using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.User_s.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.MiddleName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.LastName).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Birthday).NotNull().GreaterThan(x => (DateTime.Today.AddYears(-6)));
            RuleFor(x => x.Gender).NotNull();
            RuleFor(x => x.HasAccount).NotNull();
        }
    }
}
