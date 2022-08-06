using Ejournal.Application.Common.Helpers.Responses;

namespace Ejournal.Application.Application.Queries.ScheduleSubject_s.GetScheduleSubjectDetails
{
    public class ScheduleSubjectDetailsResponseVm : Response<ScheduleSubjectDetailsDto>
    {
        public ScheduleSubjectDetailsResponseVm(ScheduleSubjectDetailsDto data) 
            : base(data) { }
    }
}
