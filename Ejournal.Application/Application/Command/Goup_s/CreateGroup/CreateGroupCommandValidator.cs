using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Goup_s.CreateGroup
{
    public class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.SpecializationId).NotEqual(Guid.Empty);
            RuleFor(x => x.StartDate).NotNull().LessThan(x => x.EndDate);
            RuleFor(x => x.EndDate).NotNull().GreaterThan(x => x.StartDate);
        }
    }
}
