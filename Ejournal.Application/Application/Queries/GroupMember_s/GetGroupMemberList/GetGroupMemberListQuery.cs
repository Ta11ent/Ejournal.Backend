﻿using Ejournal.Application.Common.Helpers.Filters;
using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberList
{
    public class GetGroupMemberListQuery : IRequest<GroupMemberListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
        public Guid GroupId { get; set; }
    }
}
