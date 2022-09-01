using FluentValidation;
using System;

namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberList
{
    public class GetGroupMemberLIstQueryValidator : AbstractValidator<GetGroupMemberListQuery>
    {
        public GetGroupMemberLIstQueryValidator()
        {
            RuleFor(x => x.GroupId).NotEqual(Guid.Empty);
        }
    }
}
