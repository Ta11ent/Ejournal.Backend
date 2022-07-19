using FluentValidation;
using System;

namespace Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseDetails
{
    public class GetCourseDetailsQueryValidator : AbstractValidator<GetCourseDetailsQuery>
    {
        public GetCourseDetailsQueryValidator()
        {
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
        }
    }
}
