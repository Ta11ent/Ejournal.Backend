using AutoMapper;
using Ejournal.Application.Application.Command.Claim_s.CreateClaim;
using Ejournal.Application.Common.Mappings;
using System;
using System.Security.Claims;

namespace Ejournal.WebApi.Models.User
{
    public class CreateUserClaimDto : IMapWith<CreateClaimCommand>
    {
        public Guid UserId { get; set; }
        /// <summary>
        /// Need to fill ClaimValue and ClaimType field
        /// </summary>
        public Claim Claim { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserClaimDto, CreateClaimCommand>()
                .ForMember(entityDto => entityDto.UserId,
                    opt => opt.MapFrom(entity => entity.UserId))
                .ForMember(entityDto => entityDto.Claim,
                    opt => opt.MapFrom(entity => entity.Claim));
        }
    }
}
