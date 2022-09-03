using MediatR;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Ejournal.Application.Application.Command.Claim_s.CreateClaim
{
    public class CreateClaimCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Claim Claim { get; set; }
    }
}
