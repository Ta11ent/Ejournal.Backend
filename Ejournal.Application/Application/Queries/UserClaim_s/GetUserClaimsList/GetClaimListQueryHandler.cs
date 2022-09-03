using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.UserClaim_s.GetUserClaimsList
{
    public class GetClaimListQueryHandler : IRequestHandler<GetClaimListQuery, ClaimListResponseVm>
    {
        private readonly IPersonDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetClaimListQueryHandler(IPersonDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<ClaimListResponseVm> Handle(GetClaimListQuery request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.AspNetUserClaims
                .Where(x => x.UserId == request.UserId)
                .Take(request.Parametrs.PageSize)
                .ProjectTo<ClaimLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ClaimListResponseVm(entity, request.Parametrs);
        }
    }
}
