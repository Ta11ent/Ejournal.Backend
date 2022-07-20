using Ejournal.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Part_s.DeletePart
{
    public class DeletePartCommandHandler : IRequestHandler<DeletePartCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeletePartCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Unit> Handle(DeletePartCommand request, CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Parts
                .FindAsync(new object[] { request.PartId },
                cancellationToken);

            _dbContext.Parts.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
