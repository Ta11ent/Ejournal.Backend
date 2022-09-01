using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Goup_s.UpdateGroup
{
    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
    {
        public UpdateGroupCommandValidator()
        {
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
            RuleFor(x => x.SpecializationId).NotEqual(Guid.Empty);
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.StartDate).NotNull().LessThan(x => x.EndDate);
            RuleFor(x => x.EndDate).NotNull().GreaterThan(x => x.StartDate);
            RuleFor(x => x.Active).NotNull();
        }
    }
}
