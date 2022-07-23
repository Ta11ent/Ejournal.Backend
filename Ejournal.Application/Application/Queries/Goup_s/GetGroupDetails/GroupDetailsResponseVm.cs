using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupDetails
{
    public class GroupDetailsResponseVm : Response<GroupDetailsDto>
    {
        public GroupDetailsResponseVm(GroupDetailsDto data)
            : base(data) { }
    }
}
