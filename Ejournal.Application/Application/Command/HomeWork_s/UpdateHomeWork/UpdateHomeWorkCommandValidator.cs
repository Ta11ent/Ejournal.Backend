using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.HomeWork_s.UpdateHomeWork
{
    public class UpdateHomeWorkCommandValidator : AbstractValidator<UpdateHomeWorkCommand>
    {
        public UpdateHomeWorkCommandValidator()
        {
            RuleFor(x => x.HomeWorkId).NotEqual(Guid.Empty);
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
            RuleFor(x => x.SubjectId).NotEqual(Guid.Empty);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Date).NotNull().GreaterThan(x => DateTime.Today);
        }
    }
}
