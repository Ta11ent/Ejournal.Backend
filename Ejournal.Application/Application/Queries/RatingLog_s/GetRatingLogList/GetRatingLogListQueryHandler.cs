using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogList
{
    public class GetRatingLogListQueryHandler 
        : IRequestHandler<GetRatingLogListQuery, RatingLogListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetRatingLogListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }

        public async Task<RatingLogListResponseVm> Handle(GetRatingLogListQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.RaitingLogs
                    .Include(s => s.StudentGroupMember)
                        .ThenInclude(u => u.Student)
                    .Include(d => d.DepartmentMember)
                        .ThenInclude(p => p.Professor)
                    .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                    .Take(request.Parametrs.PageSize)
                    .ProjectTo<RatingLogLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new RatingLogListResponseVm(entity, request.Parametrs);
        }
    }
}
