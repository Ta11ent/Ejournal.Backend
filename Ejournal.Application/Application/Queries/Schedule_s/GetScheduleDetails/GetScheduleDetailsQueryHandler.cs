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

namespace Ejournal.Application.Application.Queries.Schedule_s.GetScheduleDetails
{
    public class GetScheduleDetailsQueryHandler : IRequestHandler<GetScheduleDetailsQuery, ScheduleDetailsResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetScheduleDetailsQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }

        public async Task<ScheduleDetailsResponseVm> Handle(GetScheduleDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.Schedules
                .Where(x => x.ScheduleId == request.ScheduleId)
                .Include(d => d.ScheduleDays)
                    .ThenInclude(ss => ss.ScheduleSubjects)
                        .ThenInclude(s => s.Subject)
                .Include(g => g.StudentGroup)
                .ProjectTo<ScheduleDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Schedule), request.ScheduleId);

            return new ScheduleDetailsResponseVm(entity);
        }

    }
}
