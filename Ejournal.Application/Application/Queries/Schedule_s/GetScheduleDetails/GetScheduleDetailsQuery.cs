using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.Schedule_s.GetScheduleDetails
{
    public class GetScheduleDetailsQuery : IRequest<ScheduleDetailsResponseVm>
    {
        public Guid ScheduleId { get; set; }
    }
}
