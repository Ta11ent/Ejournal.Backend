using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Subject_s.CreateSubject
{
    public class CreateSubjectCommandHandler : IRequestHandler<CreateSubjectCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateSubjectCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Guid> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = new Subject
            {
                SubjectId = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Active = true,
                DepartmentId = request.DepartmentId
            };

            await _dbContext.Subjects.AddAsync(subject, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return subject.SubjectId;
        }
    }
}
