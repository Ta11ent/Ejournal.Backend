using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.Schedule_s.GetScheduleDetails
{
    public class GetScheduleDetailsQueryValidator : AbstractValidator<GetScheduleDetailsQuery>
    {
        public GetScheduleDetailsQueryValidator()
        {
            RuleFor(x => x.ScheduleId).NotEqual(Guid.Empty);
        }
    }
}
