using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Part_s.CreatePart
{
    public class CreatePartCommandHandler : IRequestHandler<CreatePartCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreatePartCommandHandler(IEjournalDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }

        public async Task<Guid> Handle(CreatePartCommand request, CancellationToken cancellationToken)
        {
            var part = new Part
            {
                PartId = Guid.NewGuid(),
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            await _dbContext.Parts.AddAsync(part, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return part.PartId;
        }

    }
}
