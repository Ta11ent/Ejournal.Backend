using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.UserClaim_s.DeleteClaim
{
    public class DeleteClaimCommandValidator : AbstractValidator<DeleteClaimCommand>
    {
        public DeleteClaimCommandValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.Id).NotNull();
        }
    }
}
