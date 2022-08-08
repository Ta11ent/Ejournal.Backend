using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Schedule_s.UpdateSchedule
{
    public class UpdatescheduleCommandHandler : IRequestHandler<UpdateScheduleCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdatescheduleCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Schedules
                .FirstOrDefaultAsync(x => x.ScheduleId == request.ScheduleId);

            if (entity == null)
                throw new NotFoundException(nameof(Schedule), request.ScheduleId);

            entity.Description = request.Description;
            entity.Date = request.Date;
            entity.StudentGroupId = request.GroupId;
            entity.PartId = request.PartId;
            entity.Active = request.Active;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
