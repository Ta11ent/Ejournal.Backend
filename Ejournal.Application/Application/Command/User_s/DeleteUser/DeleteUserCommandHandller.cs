using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.User_s.DeleteUser
{
    public class DeleteUserCommandHandller : IRequestHandler<DeleteUserCommand, bool>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteUserCommandHandller(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Users.
                FindAsync(new object[] { request.UserId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.UserId);

            _dbContext.Users.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.HasAccount;
        }
    }
}
