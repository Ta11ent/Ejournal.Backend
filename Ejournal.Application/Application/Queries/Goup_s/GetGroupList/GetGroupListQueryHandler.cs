using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupList
{
    public class GetGroupListQueryHandler : IRequestHandler<GetGroupListQuery, GroupListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGroupListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }

        public async Task<GroupListResponseVm> Handle(GetGroupListQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.StudentGroups
                .Where(x => x.Active == request.Parametrs.Active)
                .Include(s => s.Specialization)
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<GroupLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GroupListResponseVm(entity, request.Parametrs);
        }
    }
}
