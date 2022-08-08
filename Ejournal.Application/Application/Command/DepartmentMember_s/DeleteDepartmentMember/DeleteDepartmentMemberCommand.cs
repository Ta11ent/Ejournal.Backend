using MediatR;
using System;

namespace Ejournal.Application.Application.Command.DepartmentMember_s.DeleteDepartmentMember
{
    public class DeleteDepartmentMemberCommand : IRequest
    {
        public Guid DepartmentId { get; set; }
        public Guid MembershipId { get; set; }
    }
}
