using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Mark_s.CreateMark
{
    public class CreateMarkCommandHandler : IRequestHandler<CreateMarkCommand, Guid>
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateMarkCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));
        public async Task<Guid> Handle(CreateMarkCommand request, CancellationToken cancellationToken)
        {
            var entity = new Mark
            {
                MarkId = Guid.NewGuid(),
                Name = request.Name
            };

            await _dbContext.Marks.AddAsync(entity, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity.MarkId;
        }
    }
}
