using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Ejournal.Command.Department_s.CreateDepartment
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, Guid> 
    {
        private readonly IEjournalDbContext _dbContext;
        public CreateDepartmentCommandHandler(IEjournalDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(_dbContext));

        public async Task<Guid> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var departmant = new Department
            {
                DepartmentId = Guid.NewGuid(),
                Name = request.Name,
                Description = request.Description,
                Active = true
            };

            await _dbContext.Departments.AddAsync(departmant, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return departmant.DepartmentId;
        }
    }
}
