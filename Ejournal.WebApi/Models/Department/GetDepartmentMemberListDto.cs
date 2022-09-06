using AutoMapper;
using Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;
using System;

namespace Ejournal.WebApi.Models.Department
{
    public class GetDepartmentMemberListDto : IMapWith<GetDepartmentMemberListQuery>, IPaginationParams
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool? Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetDepartmentMemberListDto, GetDepartmentMemberListQuery>()
                .ForPath(entityDto => entityDto.Parametrs.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForPath(entityDto => entityDto.Parametrs.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize))
                .ForPath(entityDto => entityDto.Parametrs.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
