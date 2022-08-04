using Ejournal.Application.Common.Helpers.Filters;
using MediatR;

namespace Ejournal.Application.Application.Queries.Schedule_s.GetScheduleList
{
    public class GetScheduleListQuery : IRequest<ScheduleListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
    }
}
