using Ejournal.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.ScheduleDate_s.DeleteScheduleDate
{
    public class DeleteScheduleDayCommandHandler : IRequestHandler<DeleteScheduleDayCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteScheduleDayCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Unit> Handle(DeleteScheduleDayCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ScheduleDays
                .FindAsync(new object[] { request.Day },
                cancellationToken);

            _dbContext.ScheduleDays.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
