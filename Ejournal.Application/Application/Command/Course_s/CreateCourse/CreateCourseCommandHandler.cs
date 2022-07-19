using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Command.Course_s.CreateCourse
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;

        public CreateCourseCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course
            {
                CourseId = Guid.NewGuid(),
                Name = request.Name,
                Active = true
            };

            await _dbContext.Courses.AddAsync(course, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return course.CourseId;
        }
    }
}
