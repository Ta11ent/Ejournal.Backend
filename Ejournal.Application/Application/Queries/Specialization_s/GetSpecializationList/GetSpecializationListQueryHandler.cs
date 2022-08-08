using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationList
{
    public class GetSpecializationListQueryHandler :
        IRequestHandler<GetSpecializationListQuery, SpecializationListResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetSpecializationListQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<SpecializationListResponseVm> Handle(GetSpecializationListQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Specializations
                    .Where(sp => sp.Active == request.Parametrs.Active)
                    .Skip((request.Parametrs.Page - 1) * request.Parametrs.PageSize)
                    .Take(request.Parametrs.PageSize)
                    .ProjectTo<SpecializationLookupDto>(_mapper.ConfigurationProvider)
                    .ToListAsync(cancellationToken);

            return new SpecializationListResponseVm(entity, request.Parametrs); 
        }
    }
}
