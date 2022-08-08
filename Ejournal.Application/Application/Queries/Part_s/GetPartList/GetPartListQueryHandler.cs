using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
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
            var entity =
                await _dbContext.Parts
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<PartLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new PartListResponseVm(entity, request.Parametrs);
        }
    }
}
