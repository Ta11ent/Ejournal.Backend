using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Schedule_s.DeleteSchedule
{
    public class DeleteScheduleCommandValidator : AbstractValidator<DeleteScheduleComamnd>
    {
        public DeleteScheduleCommandValidator()
        {
            RuleFor(x => x.ScheduleId).NotEqual(Guid.Empty);
        }
    }
}
