using AutoMapper;
using Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectList;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;

namespace Ejournal.WebApi.Models.Subject
{
    public class GetSubjectListDto : IMapWith<GetSubjectListQuery>, IPaginationParams
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool? Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetSubjectListDto, GetSubjectListQuery>()
                .ForPath(entityDto => entityDto.Parametrs.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForPath(entityDto => entityDto.Parametrs.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize))
                 .ForPath(entityDto => entityDto.Parametrs.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
