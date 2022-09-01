using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDate
{
    public class CreateScheduleDayCommandValidator : AbstractValidator<CreateScheduleDayCommand>
    {
        public CreateScheduleDayCommandValidator()
        {
            RuleFor(x => x.ScheduleId).NotEqual(Guid.Empty);
            RuleFor(x => x.Day).NotNull();
        }
    }
}
