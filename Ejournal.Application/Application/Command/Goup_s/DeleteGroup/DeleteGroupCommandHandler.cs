using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Goup_s.DeleteGroup
{
    class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteGroupCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        public async Task<Unit> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.StudentGroups
                .FindAsync(new object[] { request.GroupId },
                cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(StudentGroup), request.GroupId);

            _dbContext.StudentGroups.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
