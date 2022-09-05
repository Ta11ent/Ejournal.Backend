using Ejournal.Application.Interfaces;
using Ejournal.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Command.Claim_s.CreateClaim
{
    public class CreateClaimCommandHandler : IRequestHandler<CreateClaimCommand>
    {
        private readonly IPersonDbContext _dbContext;

        public CreateClaimCommandHandler(IPersonDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(CreateClaimCommand request, CancellationToken cancellationToken)
        {
            var claim = new AspNetUserClaim
            {
               UserId = request.UserId,
               ClaimType = request.ClaimType,
               ClaimValue = request.ClaimValue
            };

            await _dbContext.AspNetUserClaims.AddAsync(claim, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
    public class CreateClaimsCommandHadndler : IRequestHandler<CreateClaimsCommand>
    {
        private readonly IPersonDbContext _dbContext;
        public CreateClaimsCommandHadndler(IPersonDbContext dbContext) =>
          _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        public async Task<Unit> Handle(CreateClaimsCommand request, CancellationToken cancellationToken)
        {
            var claims = new List<AspNetUserClaim>();
            for (int i = 0; i < request.Claims.Count; i++)
            {
                claims.Add(new AspNetUserClaim
                {
                    UserId = request.UserId,
                    ClaimType = request.Claims[i].Type,
                    ClaimValue = request.Claims[i].Value
                });
            }

            await _dbContext.AspNetUserClaims.AddRangeAsync(claims, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }


}