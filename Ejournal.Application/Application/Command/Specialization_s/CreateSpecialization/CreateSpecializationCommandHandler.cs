using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Command.Specialization_s.CreateSpecialization
{
    public class CreateSpecializationCommandHandler : IRequestHandler<CreateSpecializationCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateSpecializationCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Guid> Handle(CreateSpecializationCommand request, CancellationToken cancellationToken)
        {
            var specialization = new Specialization
            {
                SpecializationId = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                CreationDate = DateTime.Now,
                Active = true
            };

            await _dbContext.Specializations.AddAsync(specialization, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return specialization.SpecializationId;
        }
    }
}
