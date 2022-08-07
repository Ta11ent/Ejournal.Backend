using Ejournal.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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
                .Where(x =>
                    x.ScheduleDay.ScheduleId == request.ScheduleId &&
                    x.ScheduleDay.Day == request.Day &&
                    x.ScheduleSubjectId == request.ScheduleSubjectId)
                .FirstOrDefaultAsync(cancellationToken);

            _dbContext.ScheduleSubjects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
