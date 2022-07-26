using MediatR;
using System;

namespace Ejournal.Application.Application.Command.GroupMember.UpdateGroupMember
{
    public class UpdateGroupMemberCommand : IRequest
    {
        public Guid GroupMemberId { get; set; }
        public Guid GroupId { get; set; }
        public Guid StudentId { get; set; }
        public bool Active { get; set; }
    }
}
