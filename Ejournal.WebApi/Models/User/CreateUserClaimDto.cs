using AutoMapper;
using Ejournal.Application.Application.Command.Claim_s.CreateClaim;
using Ejournal.Application.Common.Mappings;
using System;
using System.Collections.Generic;

namespace Ejournal.WebApi.Models.User
{
    public class CreateUserClaimDto : IMapWith<CreateClaimCommand>
    {
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserClaimDto, CreateClaimCommand>()
                .ForMember(entityDto => entityDto.ClaimType,
                    opt => opt.MapFrom(entity => entity.ClaimType))
                .ForMember(entityDto => entityDto.ClaimValue,
                    opt => opt.MapFrom(entity => entity.ClaimValue));
        }
    }
}
