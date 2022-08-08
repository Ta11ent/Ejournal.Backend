using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.ScheduleDay_s.DeleteScheduleDate
{
    public class DeleteScheduleDayCommandHandler : IRequestHandler<DeleteScheduleDayCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteScheduleDayCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Unit> Handle(DeleteScheduleDayCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ScheduleDays
                .Where(x =>
                    x.ScheduleId == request.ScheduleId &&
                    x.Day == request.Day)
                .FirstOrDefaultAsync(cancellationToken);

            _dbContext.ScheduleDays.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
