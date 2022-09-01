using FluentValidation;
using System;

namespace Ejournal.Application.Application.Command.DepartmentMember_s.CreateDepartmetMember
{
    public class CreateDepartmentMemberCpmmandValiadator : AbstractValidator<CreateDepartmentMemberCommand>
    {
        public CreateDepartmentMemberCpmmandValiadator()
        {
            RuleFor(x => x.DepartmentId).NotEqual(Guid.Empty);
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
