using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.Mark_s.GetMarkList
{
    public class GetMarkListQueryHandler : IRequestHandler<GetMarkListQuery, MarkListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private IMapper _mapper;
        public GetMarkListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }
        public async Task<MarkListResponseVm> Handle(GetMarkListQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Marks
                .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<MarkLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MarkListResponseVm(entity, request.Parametrs);
        }
    }
}
