using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.DepartmentMember_s.UpdateDepartmentMember
{
    public class UpdateDepartmentMemberCommandHandler : IRequestHandler<UpdateDepartmentMemberCommand>
    {
        private readonly IEjournalDbContext _dbContext;

        public UpdateDepartmentMemberCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Unit> Handle(UpdateDepartmentMemberCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.DepartmentMembers
                .FirstOrDefaultAsync(dm =>
                dm.DepartmentId == request.DepartmentId && 
                dm.DepartmentMemberId == request.MembershipId,
                cancellationToken);
            if (entity == null)
                throw new NotFoundException(nameof(DepartmentMember), request.MembershipId);

            entity.UserId = request.UserId;
            entity.Active = request.Active;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
