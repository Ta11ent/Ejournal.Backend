using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogDetails
{
    public class GetRatingLogDetailsQueryValidator : AbstractValidator<GetRatingLogDetailsQuery>
    {
        public GetRatingLogDetailsQueryValidator()
        {
            RuleFor(x => x.RatingLogId).NotEqual(Guid.Empty);
        }
    }
}
