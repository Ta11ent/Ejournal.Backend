using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDay;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.ScheduleSubject_s.GetScheduleSubjectDetails
{
    public class GetScheduleSubjectDetailsQueryHandler 
        : IRequestHandler<GetScheduleSubjectDetailsQuery, ScheduleSubjectDetailsResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetScheduleSubjectDetailsQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            _mapper = mapper;
        }

        public async Task<ScheduleSubjectDetailsResponseVm> Handle(GetScheduleSubjectDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ScheduleSubjects
                .Where(x =>
                    x.ScheduleDay.ScheduleDayId == 
                        ScheduleDayAction.GenerateDayId(request.ScheduleId, request.Day) &&
                    x.ScheduleSubjectId == request.ScheduleSubjectId)
                .Include(s => s.Subject)
                .Include(d => d.DepartmentMember)
                    .ThenInclude(p => p.User)
                .ProjectTo<ScheduleSubjectDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(ScheduleSubject), request.ScheduleSubjectId);

            return new ScheduleSubjectDetailsResponseVm(entity);
        }
    }
}
