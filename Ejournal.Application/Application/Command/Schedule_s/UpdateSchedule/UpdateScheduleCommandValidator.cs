using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Schedule_s.UpdateSchedule
{
    public class UpdateScheduleCommandValidator  : AbstractValidator<UpdateScheduleCommand>
    {
        public UpdateScheduleCommandValidator()
        {
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.Description).NotEmpty().MaximumLength(200);
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
            RuleFor(x => x.PartId).NotEqual(Guid.Empty);
            RuleFor(x => x.ScheduleId).NotEqual(Guid.Empty);
            RuleFor(x => x.Active).NotNull();
        }
    }
}
