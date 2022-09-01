using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupDetails
{
    public class GetGroupDetailsQueryValidator : AbstractValidator<GetGroupDetailsQuery>
    {
        public GetGroupDetailsQueryValidator()
        {
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
        }
    }
}
