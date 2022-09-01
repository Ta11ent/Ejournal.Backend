using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.GroupMember.DeleteGroupMember
{
    public class DeleteGroupMemberCommandValidator : AbstractValidator<DeleteGroupMemberCommand>
    {
        public DeleteGroupMemberCommandValidator()
        {
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
            RuleFor(x => x.ClassMemberId).NotEqual(Guid.Empty);
        }
    }
}
