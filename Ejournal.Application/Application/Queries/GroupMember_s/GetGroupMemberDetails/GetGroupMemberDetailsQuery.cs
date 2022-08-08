using MediatR;
using System;


namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberDetails
{
    public class GetGroupMemberDetailsQuery : IRequest<GroupMemberDetailsResponseVm>
    {
        public Guid GroupId { get; set; }
        public Guid ClassMemberId { get; set; }
    }
}
