﻿using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Command.Course_s.UpdateCourse
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdateCourseCommandHandler(IEjournalDbContext dbContext) => _dbContext = dbContext;
        public async Task<Unit> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Courses.FirstOrDefaultAsync(c => c.CourseId == request.CourseId);

            if (entity == null)
                throw new NotFoundException(nameof(Course), request.CourseId);
            
            entity.Name = request.Name;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
