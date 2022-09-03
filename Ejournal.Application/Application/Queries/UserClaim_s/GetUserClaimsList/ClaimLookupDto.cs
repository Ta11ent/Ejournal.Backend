using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;

namespace Ejournal.Application.Application.Queries.UserClaim_s.GetUserClaimsList
{
    public class ClaimLookupDto : IMapWith<AspNetUserClaim>
    {
        public int Id { get; set; }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AspNetUserClaim, ClaimLookupDto>()
                .ForMember(entityDto => entityDto.Id,
                    opt => opt.MapFrom(entity => entity.Id))
                .ForMember(entityDto => entityDto.ClaimType,
                    opt => opt.MapFrom(entity => entity.ClaimType))
                .ForMember(entityDto => entityDto.ClaimValue,
                    opt => opt.MapFrom(entity => entity.ClaimValue));
        }
    }
}
