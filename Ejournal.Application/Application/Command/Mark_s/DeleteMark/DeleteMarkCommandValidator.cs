using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Mark_s.DeleteMark
{
    public class DeleteMarkCommandValidator : AbstractValidator<DeleteMarkCommand>
    {
        public DeleteMarkCommandValidator()
        {
            RuleFor(x => x.MarkId).NotEqual(Guid.Empty);
        }
    }
}
