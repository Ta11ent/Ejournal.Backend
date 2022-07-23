using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Goup_s.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateGroupCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Guid> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = new StudentGroup
            {
                StudentGroupId = Guid.NewGuid(),
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                SpecializationId = request.SpecializationId,
                Active = true
            };

            await _dbContext.StudentGroups.AddAsync(group, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return group.StudentGroupId;
        }
    }
}
