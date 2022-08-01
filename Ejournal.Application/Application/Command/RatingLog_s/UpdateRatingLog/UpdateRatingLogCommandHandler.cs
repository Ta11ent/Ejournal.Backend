using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.RatingLog_s.UpdateRatingLog
{
    public class UpdateRatingLogCommandHandler : IRequestHandler<UpdateRatingLogCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdateRatingLogCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Unit> Handle(UpdateRatingLogCommand request, CancellationToken cancellationToken)
        {
            var entity = 
                await _dbContext.RaitingLogs
                 .FirstOrDefaultAsync(c => c.RaitingLogId == request.RatingLogId);

            if (entity == null)
                throw new NotFoundException(nameof(RatingLog), request.RatingLogId);

            entity.Date = request.Date;
            entity.Description = entity.Description;
            entity.SubjectId = request.SubjectId;
            entity.MarkId = request.MarkId;
            entity.DepartmentMemberId = request.DepartmentMemberId;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
