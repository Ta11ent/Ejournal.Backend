using Ejournal.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.RatingLog_s.DeleteRatingLog
{
    public class DeleteRatingLogCommandHandler : IRequestHandler<DeleteRatingLogCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteRatingLogCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Unit> Handle(DeleteRatingLogCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.RaitingLogs
                .FindAsync(new object[] { request.RatingLogId },
                cancellationToken);

            _dbContext.RaitingLogs.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
