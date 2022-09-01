using FluentValidation;

namespace Ejournal.Application.Application.Command.Mark_s.CreateMark
{
    public class CreateMarkCommandValidator : AbstractValidator<CreateMarkCommand>
    {
        public CreateMarkCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20); 
        }
    }
}
