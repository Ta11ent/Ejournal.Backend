using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Application.Queries.User_s.GetUserDetails;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
            _dbContext = dbContext;
            _identityDbContext = identityDbContext;

        }

        public async Task<DepartmentMemberDetailsResponseVm> Handle(GetDepartmentMemberDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.DepartmentMembers
                  .Include(d => d.Department)
                  .FirstOrDefaultAsync(e =>
                    e.DepartmentId == request.DepartmentId &&
                    e.DepartmentMemberId == request.DepartmentMemberId,
                    cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(DepartmentMember), request.DepartmentMemberId);

            var model = _mapper.Map<DepartmentMemberDetailsDto>(entity);

            var dependentEntity =
                await _identityDbContext.AspNetUsers
                .Where(e => e.Id == entity.ProfessorId)
                .ProjectTo<UserDetailsVm>( _mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (dependentEntity == null)
                throw new NotFoundException(nameof(DepartmentMember), nameof(AspNetUser), entity.ProfessorId);

            model.Professor = dependentEntity;
   
            return new DepartmentMemberDetailsResponseVm(model);
        }
    }
}
