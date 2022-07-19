using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberDetails
{
    public class DepartmentMemberDetailsResponseVm : Response<DepartmentMemberDetailsDto>
    {
        public DepartmentMemberDetailsResponseVm(DepartmentMemberDetailsDto data)
            : base(data) { }
    }
}
