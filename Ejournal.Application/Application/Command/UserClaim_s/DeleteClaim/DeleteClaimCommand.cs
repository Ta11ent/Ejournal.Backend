using MediatR;
using System;

namespace Ejournal.Application.Application.Command.UserClaim_s.DeleteClaim
{
    public class DeleteClaimCommand : IRequest
    {
        public Guid UserId { get; set; }
        public int Id { get; set; }
    }
}
