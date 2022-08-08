using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Command.Specialization_s.DeleteSpecialization
{
    public class DeleteSpecializationCommandHandler : IRequestHandler<DeleteSpecializationCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteSpecializationCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(DeleteSpecializationCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Specializations.
                FindAsync(new object[] { request.SpecialiationId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Specialization), request.SpecialiationId);

            _dbContext.Specializations.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
