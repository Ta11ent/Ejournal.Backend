using MediatR;
using System;

namespace Ejournal.Application.Ejournal.Command.Department_s.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest
    {
        public Guid DepartmentId { get; set; }
    }
}
