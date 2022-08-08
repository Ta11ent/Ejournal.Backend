using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Command.Department_s.DeleteDepartment
{
    public class DeleteDepartmentCommandHandler : IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public DeleteDepartmentCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Departments.FindAsync(new object[] { request.DepartmentId }, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Department), request.DepartmentId);

            _dbContext.Departments.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
