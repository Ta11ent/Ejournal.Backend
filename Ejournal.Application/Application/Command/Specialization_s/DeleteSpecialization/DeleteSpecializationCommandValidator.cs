using FluentValidation;
using System;

namespace Ejournal.Application.Ejournal.Command.Specialization_s.DeleteSpecialization
{
    public class DeleteSpecializationCommandValidator : AbstractValidator<DeleteSpecializationCommand>
    {
        public DeleteSpecializationCommandValidator()
        {
            RuleFor(x => x.SpecialiationId).NotEqual(Guid.Empty);
        }
    }
}
