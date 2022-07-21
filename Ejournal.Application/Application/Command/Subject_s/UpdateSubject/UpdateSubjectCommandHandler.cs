using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Subject_s.UpdateSubject
{
    public class UpdateSubjectCommandHandler : IRequestHandler<UpdateSubjectCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdateSubjectCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        public async Task<Unit> Handle(UpdateSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await
                _dbContext.Subjects
                .FirstOrDefaultAsync(sp =>
                        sp.SubjectId == request.SubjectId,
                        cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Subject), request.SubjectId);

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.DepartmentId = request.DepartmentId;

            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
