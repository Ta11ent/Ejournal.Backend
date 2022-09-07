using AutoMapper;
using Ejournal.Application.Application.Queries.UserClaim_s.GetUserClaimsList;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;

namespace Ejournal.WebApi.Models.User
{
    public class GetUserClaimListDto : IMapWith<GetClaimListQuery>, IPaginationParams
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetUserClaimListDto, GetClaimListQuery>()
                .ForPath(entityDto => entityDto.Parametrs.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForPath(entityDto => entityDto.Parametrs.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize));
        }
    }
}
