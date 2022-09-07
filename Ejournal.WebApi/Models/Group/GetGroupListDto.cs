using AutoMapper;
using Ejournal.Application.Application.Queries.Goup_s.GetGroupList;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;
using System;

namespace Ejournal.WebApi.Models.Group
{
    public class GetGroupListDto : IMapWith<GetGroupListQuery>, IPaginationParams
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool? Active { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetGroupListDto, GetGroupListQuery>()
                .ForPath(entityDto => entityDto.Parametrs.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForPath(entityDto => entityDto.Parametrs.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize))
                .ForPath(entityDto => entityDto.Parametrs.Active,
                    opt => opt.MapFrom(entity => entity.Active))
                .ForPath(entityDto => entityDto.Parametrs.DateFrom,
                    opt => opt.MapFrom(entity => entity.DateFrom))
                .ForPath(entityDto => entityDto.Parametrs.DateTo,
                    opt => opt.MapFrom(entity => entity.DateTo));
        }

    }
}
