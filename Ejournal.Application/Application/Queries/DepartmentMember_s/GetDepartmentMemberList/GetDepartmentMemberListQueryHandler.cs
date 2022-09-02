using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Common.Helpers.Predicate;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
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
            IEjournalDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
        
        public async Task<DepartmentMemberListResponseVm> Handle(GetDepartmentMemberListQuery request,
            CancellationToken cancellationToken)
        {
            var predicate = CustomPredicateBuilder.True<DepartmentMember>();
            var entity =
                await _dbContext.DepartmentMembers
                .Where(predicate
                    .And(x => x.DepartmentId == request.DepartmentId)
                    .And(x => x.Active == request.Parametrs.Active,
                        request.Parametrs.Active))
                .Include(x => x.User)
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<DepartmentMemberLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new DepartmentMemberListResponseVm(entity, request.Parametrs);

        }
    }
}
