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

namespace Ejournal.Application.Application.Queries.Part_s.GetPartList
{
    public class GetPartListQueryHandler : IRequestHandler<GetPartListQuery, PartListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetPartListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<PartListResponseVm> Handle(GetPartListQuery request, CancellationToken cancellationToken)
        {
            var predicate = CustomPredicateBuilder.True<Part>();
            var entity =
                await _dbContext.Parts
                .Where(predicate
                    .And(x => x.Active == request.Parametrs.Active,
                        request.Parametrs.Active))
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<PartLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            var count = await _dbContext.Parts.CountAsync();

            return new PartListResponseVm(entity, request.Parametrs, count);
        }
    }
}
