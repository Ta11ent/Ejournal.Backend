using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Ejournal.Application.Application.Command.Claim_s.CreateClaim
{
    public class CreateClaimCommand : IRequest
    {
        public Guid UserId { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
    }

    public class CreateClaimsCommand : IRequest
    {
        public Guid UserId { get; set; }
        public List<Claim> Claims { get; set; }
    }
}
