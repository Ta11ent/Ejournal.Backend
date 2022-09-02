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

namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupList
{
    public class GetGroupListQueryHandler : IRequestHandler<GetGroupListQuery, GroupListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetGroupListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<GroupListResponseVm> Handle(GetGroupListQuery request,
            CancellationToken cancellationToken)
        {
            var predicate = CustomPredicateBuilder.True<StudentGroup>();
            var entity = await _dbContext.StudentGroups
                .Where(predicate
                    .And(x => x.Active == request.Parametrs.Active,
                        request.Parametrs.Active)
                    .And(x => x.StartDate >= request.Parametrs.DateFrom,
                        request.Parametrs.DateFrom)
                    .And(x => x.EndDate <=request.Parametrs.DateTo,
                        request.Parametrs.DateTo))
                .Include(s => s.Specialization)
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<GroupLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new GroupListResponseVm(entity, request.Parametrs);
        }
    }
}
