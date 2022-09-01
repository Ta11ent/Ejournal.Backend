using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.DepartmentMember_s.UpdateDepartmentMember
{
    public class UpdateDepartmentMemberCpmmandValiadator : AbstractValidator<UpdateDepartmentMemberCommand>
    {
        public UpdateDepartmentMemberCpmmandValiadator()
        {
            RuleFor(x => x.DepartmentId).NotEqual(Guid.Empty);
            RuleFor(x => x.MembershipId).NotEqual(Guid.Empty);
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
            RuleFor(x => x.Active).NotNull();
        }
    }
}
