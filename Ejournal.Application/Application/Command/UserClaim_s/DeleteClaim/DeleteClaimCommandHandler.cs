using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.UserClaim_s.DeleteClaim
{
    public class DeleteClaimCommandHandler : IRequestHandler<DeleteClaimCommand>
    {
        private readonly IPersonDbContext _dbContext;
        public DeleteClaimCommandHandler(IPersonDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Unit> Handle(DeleteClaimCommand request, CancellationToken cancellationToken)
        {
            var entity = await
               _dbContext.AspNetUserClaims
               .FirstOrDefaultAsync(dm =>
                   dm.UserId == request.UserId &&
                   dm.Id == request.Id,
                   cancellationToken);

            _dbContext.AspNetUserClaims.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
