using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationDetails
{
    public class SpecializationDetailsResponseVm : Response<SpecializationDetailsDto>
    {
        public SpecializationDetailsResponseVm(SpecializationDetailsDto data) 
            : base(data) { }
    }
}
