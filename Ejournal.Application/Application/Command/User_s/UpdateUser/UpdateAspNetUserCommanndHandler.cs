using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.User_s.UpdateUser
{
    public class UpdateAspNetUserCommanndHandler : IRequestHandler<UpdateAspNetUserCommannd>
    {
        private readonly IPersonDbContext _dbContext;
        public UpdateAspNetUserCommanndHandler(IPersonDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(UpdateAspNetUserCommannd request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext.AspNetUsers
                .FirstOrDefaultAsync(sp =>
                        sp.Id == request.UserId,
                        cancellationToken);

            if (entity == null)
                throw new NotFoundException("IdentityUser", request.UserId);

            entity.LockoutEnabled = !request.Active;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
