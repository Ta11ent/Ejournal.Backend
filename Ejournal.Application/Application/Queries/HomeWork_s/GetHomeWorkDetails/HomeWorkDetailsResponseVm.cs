using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkDetails
{
    public class HomeWorkDetailsResponseVm : Response<HomeWorkDetailsDto>
    { 
        public HomeWorkDetailsResponseVm(HomeWorkDetailsDto data)
            : base(data) { }
    }
}
