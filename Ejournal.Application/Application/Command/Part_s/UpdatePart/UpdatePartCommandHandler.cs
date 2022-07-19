using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Part_s.UpdatePart
{
    public class UpdatePartCommandHandler : IRequestHandler<UpdatePartCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdatePartCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdatePartCommand request, CancellationToken cancllationToken)
        {
            var entity = await
                 _dbContext.Parts
                 .FirstOrDefaultAsync(c => c.PartId == request.PartId);

            if (entity == null)
                throw new NotFoundException(nameof(Part), request.PartId);

            entity.Name = request.Name;
            entity.StartDate = entity.StartDate;
            entity.EndDate = request.EndDate;

            return Unit.Value;
        }
    }
}
