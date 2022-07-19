using MediatR;
using System;

namespace Ejournal.Application.Application.Command.DepartmentMember_s.UpdateDepartmentMember
{
    public class UpdateDepartmentMemberCommand : IRequest
    {
        public Guid DepartmentMemberId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid ProfessorId { get; set; }
        public bool Active { get; set; }
    }
}
