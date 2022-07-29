using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Goup_s.UpdateGroup
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdateGroupCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Unit> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var entity = await
                 _dbContext.StudentGroups
                 .FirstOrDefaultAsync(c => c.StudentGroupId == request.GroupId);

            if (entity == null)
                throw new NotFoundException(nameof(StudentGroup), request.GroupId);

            entity.Name = request.Name;
            entity.StartDate = request.StartDate;
            entity.EndDate = request.EndDate;
            entity.Active = request.Active;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
