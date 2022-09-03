﻿using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Claim_s.CreateClaim
{
    public class CreateClaimCommandValidator : AbstractValidator<CreateClaimCommand>
    {
        public CreateClaimCommandValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.Claim.Type).NotEmpty();
            RuleFor(x => x.Claim.Value).NotEmpty();
        }
    }
}
