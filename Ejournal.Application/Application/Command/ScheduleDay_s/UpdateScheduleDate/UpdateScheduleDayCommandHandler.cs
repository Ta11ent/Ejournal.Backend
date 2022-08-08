using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.ScheduleDay_s.UpdateScheduleDate
{
    public class UpdateScheduleDayCommandHandler : IRequestHandler<UpdateSchduleDayCommand>
    {
        private IEjournalDbContext _dbContext;
        public UpdateScheduleDayCommandHandler(IEjournalDbContext dbContext) =>
           _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(UpdateSchduleDayCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.ScheduleDays
                .FirstOrDefaultAsync(x => 
                    x.ScheduleId == request.ScheduleId && 
                    x.Day == request.Day);

            if (entity == null)
                throw new NotFoundException(nameof(ScheduleDay), request.Day);

            entity.Day = request.Day;
            entity.Active = request.Active;
    
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
