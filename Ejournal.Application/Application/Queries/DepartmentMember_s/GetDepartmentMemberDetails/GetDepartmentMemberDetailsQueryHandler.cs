using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Application.Queries.User_s.GetUserDetails;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberDetails
{
    public class GetDepartmentMemberDetailsQueryHandler 
        : IRequestHandler<GetDepartmentMemberDetailsQuery, DepartmentMemberDetailsResponseVm>
    {
        private readonly IMapper _mapper;
        private readonly IEjournalDbContext _dbContext;
        private readonly IPersonDbContext _identityDbContext;

        public GetDepartmentMemberDetailsQueryHandler(IMapper mapper, 
            IEjournalDbContext dbContext, IPersonDbContext identityDbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _identityDbContext = identityDbContext ?? throw new ArgumentNullException(nameof(_identityDbContext));

        }

        public async Task<DepartmentMemberDetailsResponseVm> Handle(GetDepartmentMemberDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.DepartmentMembers
                  .Include(d => d.Department)
                  .Include(p => p.User)
                  .Where(e =>
                    e.DepartmentId == request.DepartmentId &&
                    e.DepartmentMemberId == request.MembershipId)
                 .ProjectTo<DepartmentMemberDetailsDto>(_mapper.ConfigurationProvider)
                 .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(DepartmentMember), request.MembershipId);

            return new DepartmentMemberDetailsResponseVm(entity);
        }
    }
}
