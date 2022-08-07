using Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDay;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.ScheduleSubject_s.CreateScheduleSubject
{
    public class CreateScheduleSubjectCommandHandler : IRequestHandler<CreateScheduleSubjectCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateScheduleSubjectCommandHandler(IEjournalDbContext dbContext) =>
           _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Guid> Handle(CreateScheduleSubjectCommand request,
            CancellationToken cancellationToken) 
        {
            var entity = new ScheduleSubject
            {
                ScheduleSubjectId = Guid.NewGuid(),
                Order = request.Order,
                Active = true,
                ScheduleDayId = ScheduleDayAction.GenerateDayId(request.ScheduleId, request.Day),
                SubjectId = request.SubjectId,
                DepartmentMemberId = request.DepartmentMemberId
            };

            await _dbContext.ScheduleSubjects.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.ScheduleSubjectId;
        }
    }
}
