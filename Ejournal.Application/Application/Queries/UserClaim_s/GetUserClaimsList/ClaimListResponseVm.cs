using Ejournal.Application.Common.Helpers.Responses;
using Ejournal.Application.Interfaces;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.UserClaim_s.GetUserClaimsList
{
    public class ClaimListResponseVm : PageResponse<List<ClaimLookupDto>>
    {
        public ClaimListResponseVm(List<ClaimLookupDto> data, IPaginationParams parametrs) 
            : base(data, parametrs) { }
    }
}
