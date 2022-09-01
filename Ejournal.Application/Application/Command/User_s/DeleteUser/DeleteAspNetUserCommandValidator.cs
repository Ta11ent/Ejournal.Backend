using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.User_s.DeleteUser
{
    public class DeleteAspNetUserCommandValidator : AbstractValidator<DeleteAspNetUserCommand>
    {
        public DeleteAspNetUserCommandValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
