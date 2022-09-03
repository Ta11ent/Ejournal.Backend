using Ejournal.Application.Common.Helpers.Filters;
using MediatR;
using System;

namespace Ejournal.Application.Application.Queries.UserClaim_s.GetUserClaimsList
{
    public class GetClaimListQuery : IRequest<ClaimListResponseVm>
    {
        public FilterParams Parametrs { get; set; }
        public Guid UserId { get; set; }
    }
}
