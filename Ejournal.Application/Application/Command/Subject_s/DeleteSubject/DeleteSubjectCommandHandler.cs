using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Subject_s.DeleteSubject
{
    public class DeleteSubjectCommandHandler : IRequestHandler<DeleteSubjectCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteSubjectCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Subjects.
                FindAsync(new object[] { request.SubjectId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Subject), request.SubjectId);

            _dbContext.Subjects.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
