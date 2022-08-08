using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.GroupMember.CreateGroupMember
{
    public class CraeteGroupMemberCommandHandler : IRequestHandler<CreateGroupMemberCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CraeteGroupMemberCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Guid> Handle(CreateGroupMemberCommand request, CancellationToken cancellationToken)
        {
            var groupMember = new StudentGroupMember
            {
                StudentGroupMemberId = Guid.NewGuid(),
                StudentGroupId = request.GroupId,
                UserId = request.UserId,
                Active = true,
            };

            await _dbContext.StudentGroupMembers.AddAsync(groupMember, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return groupMember.StudentGroupMemberId;
        }
    }
}
