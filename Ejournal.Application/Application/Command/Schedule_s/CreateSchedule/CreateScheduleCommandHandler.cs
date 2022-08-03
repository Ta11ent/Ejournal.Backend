using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Schedule_s.CreateSchedule
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommmand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateScheduleCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Guid> Handle(CreateScheduleCommmand request, CancellationToken cancellationToken)
        {
            var schedule = new Schedule
            {
                ScheduleId = Guid.NewGuid(),
                Description = request.Description,
                Date = request.Date,
                StudentGroupId = request.GroupId,
                PartId = request.PartId,
                Active = true
            };

            await _dbContext.Schedules.AddAsync(schedule, cancellationToken);

            var days = new List<ScheduleDay>();
            for(int i = 0; i<=5; i++)
            {
                days[i].ScheduleDayId = Guid.NewGuid();
                days[i].ScheduleId = schedule.ScheduleId;
                days[i].Active = true;
                days[i].Day = (DayOfWeek)i++;
            }

            await _dbContext.ScheduleDays.AddRangeAsync(days, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return schedule.ScheduleId;
        }
    }
}
