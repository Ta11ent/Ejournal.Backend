using FluentValidation;
using System;

namespace Ejournal.Application.Ejournal.Command.Specialization_s.UpdateSpecialization
{
    public class UpdateSpecializationCommandValidator : AbstractValidator<UpdateSpecializationCommand>
    {
        public UpdateSpecializationCommandValidator()
        {
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.SpecializationId).NotEqual(Guid.Empty);
            RuleFor(x => x.Active).NotNull();

        }
    }
}
