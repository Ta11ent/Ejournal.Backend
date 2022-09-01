using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberDetails
{
    public class GetDepartmentMemberDetailsQueryValidator : AbstractValidator<GetDepartmentMemberDetailsQuery>
    {
        public GetDepartmentMemberDetailsQueryValidator()
        {
            RuleFor(x => x.DepartmentId).NotEqual(Guid.Empty);
            RuleFor(x => x.MembershipId).NotEqual(Guid.Empty);
        }
    }
}
