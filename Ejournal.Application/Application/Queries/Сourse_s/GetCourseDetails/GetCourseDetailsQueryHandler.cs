using AutoMapper;
using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseDetails
{
    public class GetCourseDetailsQueryHandler : IRequestHandler<GetCourseDetailsQuery, CourseDetailsVm>
    {
        private readonly IEjournalDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCourseDetailsQueryHandler(IEjournalDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<CourseDetailsVm> Handle(GetCourseDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext.Courses
                .FirstOrDefaultAsync(c => c.CourseId == request.CourseId, cancellationToken);

            if(entity == null)
                throw new NotFoundException(nameof(Course), request.CourseId);

            return _mapper.Map<CourseDetailsVm>(entity);
        }
    }
}
