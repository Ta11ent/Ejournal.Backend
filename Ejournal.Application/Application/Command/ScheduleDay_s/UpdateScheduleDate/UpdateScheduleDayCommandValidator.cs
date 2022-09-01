using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.ScheduleDay_s.UpdateScheduleDate
{
    public class UpdateScheduleDayCommandValidator : AbstractValidator<UpdateSchduleDayCommand>
    {
        public UpdateScheduleDayCommandValidator()
        {
            RuleFor(x => x.ScheduleId).NotEqual(Guid.Empty);
            RuleFor(x => x.Day).NotNull();
            RuleFor(x => x.Active).NotNull();
        }
    }
}
