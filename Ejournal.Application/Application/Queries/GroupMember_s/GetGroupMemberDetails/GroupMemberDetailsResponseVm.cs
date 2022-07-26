using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberDetails
{
    public class GroupMemberDetailsResponseVm : Response<GroupMemberDetailsDto>
    {
        public GroupMemberDetailsResponseVm(GroupMemberDetailsDto data)
            : base(data) { }
    }
}
