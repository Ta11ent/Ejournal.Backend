using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Part_s.UpdatePart
{
    public class UpdateParkCommandVlidator : AbstractValidator<UpdatePartCommand>
    {
        public UpdateParkCommandVlidator()
        {
            RuleFor(x => x.PartId).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(20);
        }
    }
}
