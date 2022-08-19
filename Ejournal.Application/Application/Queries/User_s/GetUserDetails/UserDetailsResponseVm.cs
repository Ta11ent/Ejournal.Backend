using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.User_s.GetUserDetails
{
    public class UserDetailsResponseVm : Response<UserDetailsDto>
    {
        public UserDetailsResponseVm(UserDetailsDto data)
            : base(data) { }
    }
}
