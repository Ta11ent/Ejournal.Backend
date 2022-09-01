using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.Goup_s.DeleteGroup
{
    public class DeleteGrouppCommandValidator : AbstractValidator<DeleteGroupCommand>
    {
        public DeleteGrouppCommandValidator()
        {
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
        }
    }
}
