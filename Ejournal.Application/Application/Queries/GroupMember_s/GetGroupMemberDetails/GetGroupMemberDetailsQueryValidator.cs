using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberDetails
{
    public class GetGroupMemberDetailsQueryValidator : AbstractValidator<GetGroupMemberDetailsQuery>
    {
        public GetGroupMemberDetailsQueryValidator()
        {
            RuleFor(x => x.ClassMemberId).NotEqual(Guid.Empty);
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
        }
    }
}
