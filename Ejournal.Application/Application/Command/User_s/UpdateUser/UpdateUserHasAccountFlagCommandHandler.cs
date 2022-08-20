using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.User_s.UpdateUser
{
    public class UpdateUserHasAccountFlagCommandHandler : IRequestHandler<UpdateUserHasAccountFlagCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdateUserHasAccountFlagCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(UpdateUserHasAccountFlagCommand request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext.Users
                .FirstOrDefaultAsync(sp =>
                        sp.UserId == request.UserId,
                        cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(User), request.UserId);

            entity.HasAccount = request.HasAccount;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
