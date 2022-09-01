using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList
{
    public class GetDepartmentMemberListQueryValidator : AbstractValidator<GetDepartmentMemberListQuery> 
    {
        public GetDepartmentMemberListQueryValidator()
        {
            RuleFor(x => x.DepartmentId).NotEqual(Guid.Empty);
        }
    }
}
