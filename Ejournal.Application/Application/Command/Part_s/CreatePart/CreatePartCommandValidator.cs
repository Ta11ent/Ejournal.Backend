using FluentValidation;

namespace Ejournal.Application.Application.Command.Part_s.CreatePart
{
    public class CreatePartCommandValidator : AbstractValidator<CreatePartCommand>
    {
        public CreatePartCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
        }
    }
}
