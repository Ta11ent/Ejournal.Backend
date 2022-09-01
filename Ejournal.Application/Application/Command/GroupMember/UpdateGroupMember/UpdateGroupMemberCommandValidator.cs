using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.GroupMember.UpdateGroupMember
{
    public class UpdateGroupMemberCommandValidator : AbstractValidator<UpdateGroupMemberCommand>
    {
        public UpdateGroupMemberCommandValidator()
        {
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.ClassMemberId).NotEqual(Guid.Empty);
            RuleFor(x => x.Active).NotNull();
        }
    }
}
