using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.User_s.UpdateUser
{
    public class UpdateAspNetUserCommandValidator : AbstractValidator<UpdateAspNetUserCommand>
    {
        public UpdateAspNetUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.Active).NotNull();
        }
    }
}
