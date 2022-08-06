using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.ScheduleSubject_s.GetScheduleSubjectDetails
{
    public class GetScheduleSubjectDetailsQuery : IRequest<ScheduleSubjectDetailsResponseVm>
    {
        public Guid ScheduleId { get; set; }
        public int Day { get; set; }
        public Guid ScheduleSubjectId { get; set; }
    }
}
