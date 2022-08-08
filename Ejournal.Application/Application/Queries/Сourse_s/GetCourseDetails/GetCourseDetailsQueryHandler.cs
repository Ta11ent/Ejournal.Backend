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

namespace Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseDetails
{
    public class GetCourseDetailsQueryHandler : IRequestHandler<GetCourseDetailsQuery, CourseDetailsResponseVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCourseDetailsQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper;
        }
        public async Task<CourseDetailsResponseVm> Handle(GetCourseDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext.Courses
                .Where(c => c.CourseId == request.CourseId)
                .ProjectTo<CourseDetailsDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync( cancellationToken);

            if(entity == null)
                throw new NotFoundException(nameof(Course), request.CourseId);

            return new CourseDetailsResponseVm(entity);
        }
    }
}
