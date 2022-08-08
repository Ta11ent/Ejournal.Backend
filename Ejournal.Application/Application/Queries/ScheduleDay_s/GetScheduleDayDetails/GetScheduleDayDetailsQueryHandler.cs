using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.ScheduleDay_s.GetScheduleDayDetails
{
    public class GetScheduleDayDetailsQueryHandler 
        : IRequestHandler<GetScheduleDayDetailsQuery, ScheduleDayDetailsResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetScheduleDayDetailsQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<ScheduleDayDetailsResponseVm> Handle(GetScheduleDayDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ScheduleDays
                .Where(x =>  
                    x.ScheduleId == request.ScheduleId &&
                    x.Day == request.Day)
                .Include(d => d.ScheduleSubjects)
                .ProjectTo<ScheduleDayDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(ScheduleDay), request.Day);

            return new ScheduleDayDetailsResponseVm(entity);
        }
    }
}
