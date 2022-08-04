using Ejournal.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Schedule_s.DeleteSchedule
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleComamnd>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteScheduleCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Unit> Handle(DeleteScheduleComamnd request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Schedules
                .FindAsync(new object[] { request.ScheduleId },
                cancellationToken);

            _dbContext.Schedules.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}
