using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.HomeWork_s.UpdateHomeWork
{
    public class UpdateHomeWorkCommandHandler : IRequestHandler<UpdateHomeWorkCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdateHomeWorkCommandHandler(IEjournalDbContext dbContext) =>
           _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        public async Task<Unit> Handle(UpdateHomeWorkCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.HomeWorks
                .FirstOrDefaultAsync(x => x.HomeWorkId == request.HomeWorkId);

            if (entity == null)
                throw new NotFoundException(nameof(HomeWork), request.HomeWorkId);

            entity.Date = request.Date;
            entity.Description = request.Description;
            entity.StudentGroupId = request.GroupId;
            entity.SubjectId = request.SubjectId;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
