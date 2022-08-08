using MediatR;
using System;

namespace Ejournal.Application.Application.Command.GroupMember.DeleteGroupMember
{
    public class DeleteGroupMemberCommand : IRequest
    {
        public Guid GroupId { get; set; }
        public Guid ClassMemberId { get; set; }
    }
}
