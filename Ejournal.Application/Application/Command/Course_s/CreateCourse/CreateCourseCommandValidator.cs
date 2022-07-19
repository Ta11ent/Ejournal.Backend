using FluentValidation;

namespace Ejournal.Application.Ejournal.Command.Course_s.CreateCourse
{
    public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
    {
        public CreateCourseCommandValidator()
        {
            RuleFor(x =>x.Name).NotEmpty().MaximumLength(30);
        }
    }
}
