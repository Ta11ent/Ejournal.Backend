using AutoMapper;
using Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkList;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;
using System;

namespace Ejournal.WebApi.Models.HomeWork
{
    public class GetHomeWorkListDto : IMapWith<GetHomeWorkListQuery>, IPaginationParams
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? GroupId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
            

        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetHomeWorkListDto, GetHomeWorkListQuery>()
                .ForPath(entityDto => entityDto.Parametrs.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForPath(entityDto => entityDto.Parametrs.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize))
                .ForPath(entityDto => entityDto.Parametrs.Subject,
                    opt => opt.MapFrom(entity => entity.SubjectId))
                .ForPath(entityDto => entityDto.Parametrs.Group,
                    opt => opt.MapFrom(entity => entity.GroupId))
                .ForPath(entityDto => entityDto.Parametrs.DateFrom,
                    opt => opt.MapFrom(entity => entity.DateFrom))
                .ForPath(entityDto => entityDto.Parametrs.DateTo,
                    opt => opt.MapFrom(entity => entity.DateTo));
        }
    }
}
