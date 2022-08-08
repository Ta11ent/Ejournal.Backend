using MediatR;
using System;

namespace Ejournal.Application.Application.Command.GroupMember.UpdateGroupMember
{
    public class UpdateGroupMemberCommand : IRequest
    {
        public Guid ClassMemberId { get; set; }
        public Guid GroupId { get; set; }
        public Guid UserId { get; set; }
        public bool Active { get; set; }
    }
}
