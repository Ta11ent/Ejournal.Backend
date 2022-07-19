using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Ejournal.Queries.Department_s.GetDeparmentDetails
{
    public class DepartmentDetailsResponseVm : Response<DepartmentDetailsDto>
    {
        public DepartmentDetailsResponseVm(DepartmentDetailsDto data) 
            : base(data) { }
    }
}
