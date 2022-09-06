using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Ejournal.Queries.Department_s.GetDepartmentList;
using Ejournal.Application.Interfaces;

namespace Ejournal.WebApi.Models.Department
{
    public class GetDepartmentListDto : IMapWith<GetDepartmentListQuery>, IPaginationParams
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool? Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetDepartmentListDto, GetDepartmentListQuery>()
                .ForPath(entityDto => entityDto.Parametrs.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForPath(entityDto => entityDto.Parametrs.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize))
                .ForPath(entityDto => entityDto.Parametrs.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
