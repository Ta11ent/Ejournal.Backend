using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Command.Department_s.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
    }
}
