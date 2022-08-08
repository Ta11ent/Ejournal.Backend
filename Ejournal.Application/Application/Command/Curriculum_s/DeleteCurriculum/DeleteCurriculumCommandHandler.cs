using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Command.Curriculum_s.DeleteCurriculum
{
    public class DeleteCurriculumCommandHandler : IRequestHandler<DeleteCurriculumCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteCurriculumCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(DeleteCurriculumCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Curriculums.FindAsync(new object[] { request.CurriculumId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Curriculum), request.CurriculumId);

            _dbContext.Curriculums.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
