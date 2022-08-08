using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Command.Curriculum_s.CreateCurriculum
{
    public class CreateCurriculumCommandHandler : IRequestHandler<CreateCurriculumCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateCurriculumCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Guid> Handle(CreateCurriculumCommand request, CancellationToken cancelllationToken)
        {
            var curriculum = new Curriculum
            {
                CurriculumId = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                SpecializationId = request.SpecializationId,
                CourseId = request.CourseId,
                Active = true
            };

            await _dbContext.Curriculums.AddAsync(curriculum);
            await _dbContext.SaveChangesAsync(cancelllationToken);
            return curriculum.CurriculumId;
        }
    }
}
