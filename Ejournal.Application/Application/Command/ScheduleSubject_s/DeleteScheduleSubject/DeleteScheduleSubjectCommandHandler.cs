using Ejournal.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.ScheduleSubject_s.DeleteScheduleSubject
{
    public class DeleteScheduleSubjectCommandHandler : IRequestHandler<DeleteScheduleSubjectCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteScheduleSubjectCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Unit> Handle(DeleteScheduleSubjectCommand request, 
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ScheduleSubjects
                .FindAsync(new object[] { request.ScheduleSubjectId },
                cancellationToken);

            _dbContext.ScheduleSubjects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
