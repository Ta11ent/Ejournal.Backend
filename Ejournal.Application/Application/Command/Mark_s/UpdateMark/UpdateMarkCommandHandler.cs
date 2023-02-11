using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Mark_s.UpdateMark
{
    public class UpdateMarkCommandHandler : IRequestHandler<UpdateMarkCommand>
    {
        private readonly IEjournalDbContext _dbContxt;
        public UpdateMarkCommandHandler(IEjournalDbContext dbContext) =>
            _dbContxt = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(UpdateMarkCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContxt.Marks
                .FirstOrDefaultAsync(m => m.MarkId == request.MarkId);
            if (entity == null)
                throw new NotFoundException(nameof(Mark), request.MarkId);

            entity.Name = request.Name;
            entity.Active = request.Active;
            await _dbContxt.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
