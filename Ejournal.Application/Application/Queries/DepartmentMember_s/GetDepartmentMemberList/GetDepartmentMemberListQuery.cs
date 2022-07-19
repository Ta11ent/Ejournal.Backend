using Ejournal.Application.Common.Helpers.Filters;
using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList
{
    public class GetDepartmentMemberListQuery : IRequest<DepartmentMemberListResponseVm>
    {
        public PaginationParams Parametrs { get; set; }
        public Guid DepartmentId { get; set; }
        public bool Active { get; set; }
    }
}
