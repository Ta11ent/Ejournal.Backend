using FluentValidation;
using System;


namespace Ejournal.Application.Application.Queries.ScheduleSubject_s.GetScheduleSubjectDetails
{
    public class GetScheduleSubjectDetailsQueryValidator : AbstractValidator<GetScheduleSubjectDetailsQuery>
    {
        public GetScheduleSubjectDetailsQueryValidator()
        {
            RuleFor(x => x.ScheduleId).NotEqual(Guid.Empty);
            RuleFor(x => x.ScheduleSubjectId).NotEqual(Guid.Empty);
            RuleFor(x => x.Day).NotNull(); 
        }
    }
}
