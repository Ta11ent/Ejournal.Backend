using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Command.Course_s.DeleteCourse
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteCourseCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var entity =
               await _dbContext.Courses.FindAsync(new object[] { request.CourseId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Course), request.CourseId);

             _dbContext.Courses.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;

        }
    }
}
