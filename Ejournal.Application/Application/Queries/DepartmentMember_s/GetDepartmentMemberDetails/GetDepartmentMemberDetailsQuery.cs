using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberDetails
{
    public class GetDepartmentMemberDetailsQuery : IRequest<DepartmentMemberDetailsResponseVm>
    {
        public Guid DepartmentId { get; set; }
        public Guid DepartmentMemberId { get; set; }
    }
}