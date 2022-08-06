using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.ScheduleSubject_s.UpdateScheduleSubject
{
    public class UpdateScheduleSubjectCommandHandler : IRequestHandler<UpdateScheduleSubjectCommand>
    {
        private IEjournalDbContext _dbContext;
        public UpdateScheduleSubjectCommandHandler(IEjournalDbContext dbContext) =>
           _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        public async Task<Unit> Handle(UpdateScheduleSubjectCommand request, 
            CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ScheduleSubjects
                .FirstOrDefaultAsync(x =>
                    x.ScheduleDay.ScheduleId == request.ScheduleId &&
                    x.ScheduleDay.Day == request.Day &&
                    x.ScheduleSubjectId == request.ScheduleSubjectId,
                    cancellationToken);
                   

            if (entity == null)
                throw new NotFoundException(nameof(ScheduleSubject), request.Day);

            entity.Order = request.Order;
            entity.Active = request.Active;
            entity.SubjectId = request.SubjectId;
            entity.DepartmentMemberId = request.DepartmentMemberId;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
