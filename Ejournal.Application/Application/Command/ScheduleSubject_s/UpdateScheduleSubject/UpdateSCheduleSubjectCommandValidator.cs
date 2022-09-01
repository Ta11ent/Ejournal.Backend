using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.ScheduleSubject_s.UpdateScheduleSubject
{
    public class UpdateSCheduleSubjectCommandValidator : AbstractValidator<UpdateScheduleSubjectCommand>
    {
        public UpdateSCheduleSubjectCommandValidator()
        {
            RuleFor(x => x.DepartmentMemberId).NotEqual(Guid.Empty);
            RuleFor(x => x.ScheduleId).NotEqual(Guid.Empty);
            RuleFor(x => x.SubjectId).NotEqual(Guid.Empty);
            RuleFor(x => x.Day).NotNull();
            RuleFor(x => x.Order).NotNull();
            RuleFor(x => x.Active).NotNull();
            RuleFor(x => x.ScheduleSubjectId).NotEqual(Guid.Empty);
        }
    }
}
