using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.GroupMember.CreateGroupMember
{
    public class CreateGroupMemberCommandValidator : AbstractValidator<CreateGroupMemberCommand>
    {
        public CreateGroupMemberCommandValidator()
        {
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
