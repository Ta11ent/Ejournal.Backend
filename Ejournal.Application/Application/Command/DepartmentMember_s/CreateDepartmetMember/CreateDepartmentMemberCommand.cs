using MediatR;
using System;

namespace Ejournal.Application.Application.Command.DepartmentMember_s.CreateDepartmetMember
{
    public class CreateDepartmentMemberCommand : IRequest<Guid>
    {
        public Guid DepartmentId { get; set; }
        public Guid ProfessorId { get; set; }
        public bool bActive { get; set; }
    }
}
