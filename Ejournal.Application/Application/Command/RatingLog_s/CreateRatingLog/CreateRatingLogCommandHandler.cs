using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.RatingLog_s.CreateRatingLog
{
    public class CreateRatingLogCommandHandler : IRequestHandler<CreateRatingLogCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateRatingLogCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Guid> Handle(CreateRatingLogCommand request, CancellationToken cancellationToken)
        {
            var retingLog = new RatingLog
            {
               RaitingLogId = Guid.NewGuid(),
               Date = request.Date,
               Description = request.Description,
               MarkId = request.MarkId,
               StudentGroupMemberId = request.GroupMemberId,
               DepartmentMemberId = request.DepartmentMemberId,
               SubjectId = request.SubjectId
            };

            await _dbContext.RaitingLogs.AddAsync(retingLog, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return retingLog.RaitingLogId;
        }
    }
}
