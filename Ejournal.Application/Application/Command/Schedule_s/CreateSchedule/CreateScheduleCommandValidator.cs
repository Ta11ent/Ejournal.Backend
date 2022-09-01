using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Schedule_s.CreateSchedule
{
    public class CreateScheduleCommandValidator : AbstractValidator<CreateScheduleCommand>
    {
        public CreateScheduleCommandValidator()
        {
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
            RuleFor(x => x.PartId).NotEqual(Guid.Empty);
        }
    }
}
