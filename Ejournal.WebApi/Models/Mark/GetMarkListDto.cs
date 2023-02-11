using AutoMapper;
using Ejournal.Application.Application.Queries.Mark_s.GetMarkList;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;


namespace Ejournal.WebApi.Models.Mark
{
    public class GetMarkListDto : IMapWith<GetMarkListQuery>, IPaginationParams
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool? Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetMarkListDto, GetMarkListQuery>()
                .ForPath(entityDto => entityDto.Parametrs.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForPath(entityDto => entityDto.Parametrs.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize))
                .ForPath(entityDto => entityDto.Parametrs.Active,
                    opt => opt.MapFrom(enttiy => enttiy.Active));
        }

    }
}
