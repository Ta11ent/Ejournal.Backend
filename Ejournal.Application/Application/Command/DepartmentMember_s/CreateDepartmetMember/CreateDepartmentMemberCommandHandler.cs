using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.DepartmentMember_s.CreateDepartmetMember
{
    public class CreateDepartmentMemberCommandHandler : IRequestHandler<CreateDepartmentMemberCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateDepartmentMemberCommandHandler(IEjournalDbContext dbcontext) =>
            _dbContext = dbcontext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Guid> Handle(CreateDepartmentMemberCommand request, CancellationToken cancellatiionToken)
        {
            var deparmentMember = new DepartmentMember
            {
                DepartmentMemberId = Guid.NewGuid(),
                DepartmentId = request.DepartmentId,
                UserId = request.UserId,
                Active = true
            };

            await _dbContext.DepartmentMembers.AddAsync(deparmentMember, cancellatiionToken);
            await _dbContext.SaveChangesAsync(cancellatiionToken);

            return deparmentMember.DepartmentMemberId;
        }
    }
}
