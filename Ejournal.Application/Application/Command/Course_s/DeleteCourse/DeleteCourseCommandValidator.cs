using FluentValidation;
using System;

namespace Ejournal.Application.Ejournal.Command.Course_s.DeleteCourse
{
    public class DeleteCourseCommandValidator : AbstractValidator<DeleteCourseCommand>
    {
        public DeleteCourseCommandValidator()
        {
            RuleFor(x => x.CourseId).NotEqual(Guid.Empty);
        }
    }
}
