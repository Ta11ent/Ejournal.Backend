using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.ScheduleDate_s.CreateCheduleDate
{
    internal class CreateScheduleDateCommandHandler : IRequestHandler<CreateScheduleDateCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        internal CreateScheduleDateCommandHandler(IEjournalDbContext dbContext) =>
           _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Guid> Handle(CreateScheduleDateCommand request,
            CancellationToken cancellationToken)
        {
            var day = new ScheduleDay
            {
                ScheduleDayId = Guid.NewGuid(),
                ScheduleId = request.ScheduleId,
                Day = request.Day,
                Active = true
            };

            await _dbContext.ScheduleDays.AddAsync(day, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return day.ScheduleDayId;
        }
    }
}
