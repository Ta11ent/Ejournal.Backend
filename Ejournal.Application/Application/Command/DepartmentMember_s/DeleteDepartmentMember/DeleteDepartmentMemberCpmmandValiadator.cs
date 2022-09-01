using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.DepartmentMember_s.DeleteDepartmentMember
{
    public class DeleteDepartmentMemberCpmmandValiadator : AbstractValidator<DeleteDepartmentMemberCommand>
    {
        public DeleteDepartmentMemberCpmmandValiadator()
        {
            RuleFor(x => x.DepartmentId).NotEqual(Guid.Empty);
            RuleFor(x => x.MembershipId).NotEqual(Guid.Empty);
        }
    }
}
