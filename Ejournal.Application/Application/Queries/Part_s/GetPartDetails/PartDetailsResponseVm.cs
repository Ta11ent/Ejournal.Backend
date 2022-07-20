using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.Part_s.GetPartDetails
{
    public class PartDetailsResponseVm : Response<PartDetailsDto>
    {
        public PartDetailsResponseVm(PartDetailsDto data)
            : base(data) { }
    }
}
