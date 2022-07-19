using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Command.Department_s.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
