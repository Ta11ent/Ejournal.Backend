using FluentValidation;

namespace Ejournal.Application.Application.Command.Mark_s.UpdateMark
{
    public class UpdateMarkCommandValidator : AbstractValidator<UpdateMarkCommand>
    {
        public UpdateMarkCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
            RuleFor(x => x.Active).NotNull();
        }
    }
}
