using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Part_s.DeletePart
{
    public class DeletePartCommandValidator : AbstractValidator<DeletePartCommand>
    {
        public DeletePartCommandValidator()
        {
            RuleFor(x => x.PartId).NotEqual(Guid.Empty);
        }
    }
}
