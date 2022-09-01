using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.ScheduleSubject_s.DeleteScheduleSubject
{
    public class DeleteScheduleSubjectCommandValidator : AbstractValidator<DeleteScheduleSubjectCommand>
    {
        public DeleteScheduleSubjectCommandValidator()
        {
            RuleFor(x => x.ScheduleId).NotEqual(Guid.Empty);
            RuleFor(x => x.Day).NotNull();
            RuleFor(x => x.ScheduleSubjectId).NotEqual(Guid.Empty);
        }
    }
}
