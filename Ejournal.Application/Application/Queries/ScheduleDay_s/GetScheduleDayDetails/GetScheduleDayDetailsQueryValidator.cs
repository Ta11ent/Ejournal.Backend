using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.ScheduleDay_s.GetScheduleDayDetails
{
    public class GetScheduleDayDetailsQueryValidator : AbstractValidator<GetScheduleDayDetailsQuery>
    {
        public GetScheduleDayDetailsQueryValidator()
        {
            RuleFor(x => x.ScheduleId).NotEqual(Guid.Empty);
            RuleFor(x => x.Day).NotNull();
        }
    }
}
