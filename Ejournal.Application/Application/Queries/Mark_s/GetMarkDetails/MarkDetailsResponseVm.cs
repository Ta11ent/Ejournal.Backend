using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.Mark_s.GetMarkDetails
{
    public class MarkDetailsResponseVm : Response<MarkDetailsDto>
    {
        public MarkDetailsResponseVm(MarkDetailsDto data)
            : base(data) { }
    }
}
