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

namespace Ejournal.Application.Application.Queries.Schedule_s.GetScheduleList
{
    public class GetScheduleListQueryHandler 
        : IRequestHandler<GetScheduleListQuery, ScheduleListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetScheduleListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }

        public async Task<ScheduleListResponseVm> Handle(GetScheduleListQuery request, CancellationToken cancellationToken)
        {
            var predicate = CustomPredicateBuilder.True<Schedule>();

            var entity =
                await _dbContext.Schedules
                .Where(predicate
                    .And(x => x.Active == request.Parametrs.Active)
                    .And(x => x.StudentGroupId == request.Parametrs.Group, 
                        request.Parametrs.Group))
                .Include(g => g.StudentGroup)
                .Include(p => p.Part)
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<ScheduleLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ScheduleListResponseVm(entity, request.Parametrs);
        }
    }
}
