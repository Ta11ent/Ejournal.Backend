using FluentValidation;

namespace Ejournal.Application.Ejournal.Command.Specialization_s.CreateSpecialization
{
    public class CreateSpecializationCommandValidator : AbstractValidator<CreateSpecializationCommand>
    {
        public CreateSpecializationCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
        }
    }
}
