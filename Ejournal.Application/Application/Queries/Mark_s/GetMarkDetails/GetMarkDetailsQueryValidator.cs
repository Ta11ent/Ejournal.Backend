using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.Mark_s.GetMarkDetails
{
    public class GetMarkDetailsQueryValidator : AbstractValidator<GetMarkDetailsQuery>
    {
        public GetMarkDetailsQueryValidator()
        {
            RuleFor(x => x.MarkId).NotEqual(Guid.Empty);
        }
    }
}
