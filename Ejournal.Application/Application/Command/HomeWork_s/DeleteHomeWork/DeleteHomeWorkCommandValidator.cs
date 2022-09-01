using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.HomeWork_s.DeleteHomeWork
{
    public class DeleteHomeWorkCommandValidator : AbstractValidator<DeleteHomeWorkCommand>
    {
        public DeleteHomeWorkCommandValidator()
        {
            RuleFor(x => x.HomeWorkId).NotEqual(Guid.Empty);
        }
    }
}
