using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.HomeWork_s.CreateHomeWork
{
    public class CreateHomeWorkCommandHandler : IRequestHandler<CreateHomeWorkCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateHomeWorkCommandHandler(IEjournalDbContext dbContext)
            => _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Guid> Handle(CreateHomeWorkCommand request, CancellationToken cancellationToken)
        {
            var entity = new HomeWork
            {
                HomeWorkId = Guid.NewGuid(),
                Date = request.Date,
                Description = request.Description,
                StudentGroupId = request.GroupId,
                SubjectId = request.SubjectId
            };

            await _dbContext.HomeWorks.AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.HomeWorkId;
        }
    }
}
