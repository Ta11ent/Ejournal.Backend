using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectDetails
{
    public class SubjectDetailsResponseVm : Response<SubjectDetailsDto>
    {
        public SubjectDetailsResponseVm(SubjectDetailsDto data)
            : base(data) { }
    }
}
