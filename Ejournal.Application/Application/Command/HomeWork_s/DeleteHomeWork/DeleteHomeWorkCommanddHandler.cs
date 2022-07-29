using Ejournal.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.HomeWork_s.DeleteHomeWork
{
    public class DeleteHomeWorkCommanddHandler : IRequestHandler<DeleteHomeWorkCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteHomeWorkCommanddHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Unit> Handle(DeleteHomeWorkCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.HomeWorks
                .FindAsync(new object[] { request.HomeWorkId });

            _dbContext.HomeWorks.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
