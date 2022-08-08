using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList
{
    public class GetDepartmentMemberListQueryHandler 
        : IRequestHandler<GetDepartmentMemberListQuery, DepartmentMemberListResponseVm>
    {
        private readonly IMapper _mapper;
        private readonly IEjournalDbContext _dbContext;
        
        public GetDepartmentMemberListQueryHandler(IMapper mapper,
            IEjournalDbContext dbContext,  IPersonDbContext identityDbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        }
        
        public async Task<DepartmentMemberListResponseVm> Handle(GetDepartmentMemberListQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.DepartmentMembers
                .Where(dm =>
                    dm.DepartmentId == request.DepartmentId &&
                    dm.Active == request.Parametrs.Active)
                .Include(x => x.User)
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<DepartmentMemberLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DepartmentMemberListResponseVm(entity, request.Parametrs);

        }
    }
}
