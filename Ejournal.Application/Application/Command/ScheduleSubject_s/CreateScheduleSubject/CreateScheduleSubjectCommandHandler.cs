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
            var subject = new ScheduleSubject
            {
                Order = request.Order,
                Active = true,
                ScheduleDayId = request.ScheduleDayId,
                SubjectId = request.SubjectId,
                DepartmentMemberId = request.DepartmentMemberId
            };

            await _dbContext.ScheduleSubjects.AddAsync(subject, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return subject.ScheduleSubjectId;
        }
    }
}
