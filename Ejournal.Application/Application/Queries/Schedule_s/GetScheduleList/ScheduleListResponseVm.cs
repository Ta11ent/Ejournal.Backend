using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;


namespace Ejournal.Application.Application.Queries.Schedule_s.GetScheduleList
{
    public class ScheduleListResponseVm : PageResponse<List<ScheduleLookupDto>>
    {
        public ScheduleListResponseVm(List<ScheduleLookupDto> data, IPaginationParams parametrs)
            : base(data, parametrs) { }
    }
}
