using AutoMapper;
using Ejournal.Application.Application.Queries.Schedule_s.GetScheduleList;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;
using System;

namespace Ejournal.WebApi.Models.Schedule
{
    public class GetScheduleListDto : IMapWith<GetScheduleListQuery>, IPaginationParams
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool? Active { get; set; }
        public Guid? GroupId { get; set; }
        public DateTime? DateFrom { get; set; } 
        public DateTime? DateTo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetScheduleListDto, GetScheduleListQuery>()
                .ForPath(entityDto => entityDto.Parametrs.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForPath(entityDto => entityDto.Parametrs.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize))
                 .ForPath(entityDto => entityDto.Parametrs.Active,
                    opt => opt.MapFrom(entity => entity.Active))
                  .ForPath(entityDto => entityDto.Parametrs.Group,
                    opt => opt.MapFrom(entity => entity.GroupId))
                   .ForPath(entityDto => entityDto.Parametrs.DateFrom,
                    opt => opt.MapFrom(entity => entity.DateFrom))
                   .ForPath(entityDto => entityDto.Parametrs.DateTo,
                    opt => opt.MapFrom(entity => entity.DateTo));
        }

    }
}
