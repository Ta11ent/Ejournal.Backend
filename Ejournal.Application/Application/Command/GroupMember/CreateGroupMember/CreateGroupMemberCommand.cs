using MediatR;
using System;

namespace Ejournal.Application.Application.Command.GroupMember.CreateGroupMember
{
    public class CreateGroupMemberCommand : IRequest<Guid>
    {
        public Guid GroupId { get; set; }
        public Guid StudentId { get; set; }
    }
}
