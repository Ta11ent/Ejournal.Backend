using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Command.Curriculum_s.UpdateCurriculum
{
    public class UpdateCurriculumCommandHandler : IRequestHandler<UpdateCurriculumCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdateCurriculumCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
            
        public async Task<Unit> Handle(UpdateCurriculumCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Curriculums.FirstOrDefaultAsync(c => c.CurriculumId == request.CourseId);

            if (entity == null)
                throw new NotFoundException(nameof(Curriculum), request.CourseId);

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.SpecializationId = request.SpecializationId;
            entity.CourseId = request.CourseId;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}

