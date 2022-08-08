using Ejournal.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Ejournal.Command.Specialization_s.UpdateSpecialization
{
    public class UpdateSpecializationCommandHandler : IRequestHandler<UpdateSpecializationCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdateSpecializationCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(UpdateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var entity = await 
                _dbContext.Specializations
                .FirstOrDefaultAsync(sp =>
                        sp.SpecializationId == request.SpecializationId,
                        cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Specialization), request.SpecializationId);

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Active = request.Active;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
