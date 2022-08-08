using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogDetails
{
    public class GetRatingLogDetailsQueryHandler
        : IRequestHandler<GetRatingLogDetailsQuery, RatingLogDetailsReponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetRatingLogDetailsQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

     

        public async Task<RatingLogDetailsReponseVm> Handle(GetRatingLogDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.RaitingLogs
                .Where(x => x.RaitingLogId == request.RatingLogId)
                .Include(s => s.StudentGroupMember)
                    .ThenInclude(u => u.User)
                .Include(d => d.DepartmentMember)
                    .ThenInclude(p => p.User)
                .ProjectTo<RatingLogDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(RatingLog), request.RatingLogId);

            return new RatingLogDetailsReponseVm(entity);
        }
    }
}
