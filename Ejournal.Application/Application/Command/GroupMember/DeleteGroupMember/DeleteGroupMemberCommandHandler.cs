using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.GroupMember.DeleteGroupMember
{
    public class DeleteGroupMemberCommandHandler : IRequestHandler<DeleteGroupMemberCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteGroupMemberCommandHandler(IEjournalDbContext dbContext) =>
           _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(DeleteGroupMemberCommand request, CancellationToken cancellationToken)
        {
            var entity = await
              _dbContext.StudentGroupMembers
              .FirstOrDefaultAsync(gm =>
                  gm.StudentGroupId == request.GroupId &&
                  gm.StudentGroupMemberId == request.ClassMemberId,
                  cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(StudentGroupMember), request.ClassMemberId);

            _dbContext.StudentGroupMembers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
