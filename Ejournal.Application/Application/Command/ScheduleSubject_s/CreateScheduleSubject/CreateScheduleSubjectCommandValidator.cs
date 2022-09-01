using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.ScheduleSubject_s.CreateScheduleSubject
{
    public class CreateScheduleSubjectCommandValidator : AbstractValidator<CreateScheduleSubjectCommand>
    {
        public CreateScheduleSubjectCommandValidator()
        {
            RuleFor(x => x.DepartmentMemberId).NotEqual(Guid.Empty);
            RuleFor(x => x.ScheduleId).NotEqual(Guid.Empty);
            RuleFor(x => x.SubjectId).NotEqual(Guid.Empty);
            RuleFor(x => x.Day).NotNull();
            RuleFor(x => x.Order).NotNull();
        }
    }
}
