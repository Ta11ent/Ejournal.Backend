using Ejournal.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Mark_s.DeleteMark
{
    public class DeleteMarkCommandHandler : IRequestHandler<DeleteMarkCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteMarkCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Unit> Handle(DeleteMarkCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Marks
                .FindAsync(new object[] { request.MarkId });

            _dbContext.Marks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
