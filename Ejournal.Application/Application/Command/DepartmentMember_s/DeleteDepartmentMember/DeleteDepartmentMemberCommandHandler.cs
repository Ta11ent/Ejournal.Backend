using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.DepartmentMember_s.DeleteDepartmentMember
{
    public class DeleteDepartmentMemberCommandHandler : IRequestHandler<DeleteDepartmentMemberCommand>
    {
        private readonly IEjournalDbContext _dbContext;

        public DeleteDepartmentMemberCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(DeleteDepartmentMemberCommand request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext.DepartmentMembers
                .FirstOrDefaultAsync(dm => 
                    dm.DepartmentId == request.DepartmentId && 
                    dm.DepartmentMemberId == request.MembershipId, 
                    cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(DepartmentMember), request.MembershipId);

            _dbContext.DepartmentMembers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
