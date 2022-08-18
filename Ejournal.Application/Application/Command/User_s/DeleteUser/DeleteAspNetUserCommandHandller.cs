using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.User_s.DeleteUser
{
    public class DeleteAspNetUserCommandHandller : IRequestHandler<DeleteAspNetUserCommand>
    {
        private readonly IPersonDbContext _dbContext;
        public DeleteAspNetUserCommandHandller(IPersonDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(DeleteAspNetUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.AspNetUsers.
                FindAsync(new object[] { request.UserId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException("IdentityUser", request.UserId);

            _dbContext.AspNetUsers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
