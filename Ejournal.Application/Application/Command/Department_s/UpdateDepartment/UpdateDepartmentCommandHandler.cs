using Ejournal.Application.Common.Exceptions;
using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Command.Department_s.UpdateDepartment
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand>
    {
        private readonly IEjournalDbContext _dbContext;
        public UpdateDepartmentCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Departments.FirstOrDefaultAsync(dt =>
                dt.DepartmentId == request.DepartmentId, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(Department), request.DepartmentId);

            entity.Name = request.Name;
            entity.Description = request.Description;
            entity.Active = request.Active;
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
