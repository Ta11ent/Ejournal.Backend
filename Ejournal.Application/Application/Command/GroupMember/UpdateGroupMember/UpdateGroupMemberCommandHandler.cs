using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.GroupMember.UpdateGroupMember
{
    public class UpdateGroupMemberCommandHandler : IRequestHandler<UpdateGroupMemberCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdateGroupMemberCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Unit> Handle(UpdateGroupMemberCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.StudentGroupMembers
                .FirstOrDefaultAsync(gm => 
                gm.StudentGroupId == request.GroupId &&
                gm.StudentGroupMemberId == request.ClassMemberId,
                cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(StudentGroupMember), request.ClassMemberId);

            entity.StudentGroupId = request.GroupId;
            entity.UserId = request.UserId;
            entity.Active = request.Active;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
