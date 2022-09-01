using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.Part_s.GetPartDetails
{
    public class GetPartDetailsQueryValidator : AbstractValidator<GetPartDetailsQuery>
    {
        public GetPartDetailsQueryValidator()
        {
            RuleFor(x => x.PartId).NotEqual(Guid.Empty);
        }
    }
}
