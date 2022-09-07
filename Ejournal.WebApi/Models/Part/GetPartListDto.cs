using AutoMapper;
using Ejournal.Application.Application.Queries.Part_s.GetPartList;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;

namespace Ejournal.WebApi.Models.Part
{
    public class GetPartListDto : IMapWith<GetPartListQuery>, IPaginationParams
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetPartListDto, GetPartListQuery>()
                .ForPath(entityDto => entityDto.Parametrs.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForPath(entityDto => entityDto.Parametrs.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize));
        }
    }
}
