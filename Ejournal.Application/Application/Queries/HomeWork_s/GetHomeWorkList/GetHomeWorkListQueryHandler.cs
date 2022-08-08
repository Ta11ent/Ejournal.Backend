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

namespace Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkList
{
    public class GetHomeWorkListQueryHandler : IRequestHandler<GetHomeWorkListQuery, HomeWorkListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private IMapper _mapper;
        public GetHomeWorkListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }
        public async Task<HomeWorkListResponseVm> Handle(GetHomeWorkListQuery request, 
            CancellationToken cancellationToken)
        {
            var predicate = CustomPredicateBuilder.True<HomeWork>();
            var entity =
                await _dbContext.HomeWorks
                .Where(predicate
                    .And(x => x.SubjectId == request.Parametrs.Subject, 
                        request.Parametrs.Subject)
                    .And(x => x.StudentGroupId == request.Parametrs.Group,
                        request.Parametrs.Group)
                    .And(x => x.Date >= request.Parametrs.DateFrom)
                    .And(x => x.Date <= request.Parametrs.DateTo))
                .Include(s => s.Subject)
                .Include(g => g.StudentGroup)
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<HomeWorkLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new HomeWorkListResponseVm(entity, request.Parametrs);
        }
    }
}
////x =>
//x.Date >= request.Parametrs.DateFrom &&
//x.Date <= request.Parametrs.DateTo