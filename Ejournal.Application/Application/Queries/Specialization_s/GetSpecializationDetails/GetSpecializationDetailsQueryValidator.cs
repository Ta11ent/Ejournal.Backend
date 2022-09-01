using FluentValidation;
using System;

namespace Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationDetails
{
    public class GetSpecializationDetailsQueryValidator : AbstractValidator<GetSpecializationDetailsQuery>
    {
        public GetSpecializationDetailsQueryValidator()
        {
            RuleFor(x => x.SpecializationId).NotEqual(Guid.Empty);
        }
    }
}
