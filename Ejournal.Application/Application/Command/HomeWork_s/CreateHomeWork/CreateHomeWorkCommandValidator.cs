using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.HomeWork_s.CreateHomeWork
{
    public class CreateHomeWorkCommandValidator : AbstractValidator<CreateHomeWorkCommand>
    {
        public CreateHomeWorkCommandValidator()
        {
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
            RuleFor(x => x.SubjectId).NotEqual(Guid.Empty);
            RuleFor(x => x.Description).NotEmpty().MaximumLength(250);
            RuleFor(x => x.Date).NotNull().GreaterThan(x => DateTime.Today);
        }
    }
}
