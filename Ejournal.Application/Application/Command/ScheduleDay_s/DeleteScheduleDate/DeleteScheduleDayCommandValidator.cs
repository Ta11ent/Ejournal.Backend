using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.ScheduleDay_s.DeleteScheduleDate
{
    public class DeleteScheduleDayCommandValidator : AbstractValidator<DeleteScheduleDayCommand>
    {
        public DeleteScheduleDayCommandValidator()
        {
            RuleFor(x => x.Day).NotNull();
            RuleFor(x => x.ScheduleId).NotEqual(Guid.Empty);
        }
    }
}
