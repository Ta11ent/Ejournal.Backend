using Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDay;
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

            _dbContext.Schedules.Add(schedule);

            var days = new List<Domain.ScheduleDay>();
            for (int i = 0; i <= 5; i++)
            {
                days.Add(ScheduleDayAction.Create(schedule.ScheduleId, i + 1));
            }

            await _dbContext.ScheduleDays.AddRangeAsync(days, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return schedule.ScheduleId;
        }
    }
}
