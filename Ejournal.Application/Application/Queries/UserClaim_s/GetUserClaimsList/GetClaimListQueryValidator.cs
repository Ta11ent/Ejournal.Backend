using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.UserClaim_s.GetUserClaimsList
{
    public class GetClaimListQueryValidator : AbstractValidator<GetClaimListQuery>
    {
        public GetClaimListQueryValidator()
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
