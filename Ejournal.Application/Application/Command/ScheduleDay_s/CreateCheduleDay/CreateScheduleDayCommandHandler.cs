using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDate
{
    public class CreateScheduleDayCommandHandler : IRequestHandler<CreateScheduleDayCommand, int>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateScheduleDayCommandHandler(IEjournalDbContext dbContext) =>
           _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<int> Handle(CreateScheduleDayCommand request,
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

            return (int)day.Day;
        }
    }
}
