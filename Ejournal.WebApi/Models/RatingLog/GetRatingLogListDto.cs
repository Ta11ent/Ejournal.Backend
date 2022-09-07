using AutoMapper;
using Ejournal.Application.Application.Queries.RatingLog_s.GetRatingLogList;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;
using System;

namespace Ejournal.WebApi.Models.RatingLog
{
    public class GetRatingLogListDto : IMapWith<GetRatingLogListQuery>, IPaginationParams
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public Guid? MembershipId { get; set; }
        public Guid? ClassMemberId { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? GroupId { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetRatingLogListDto, GetRatingLogListQuery>()
                .ForPath(entityDto => entityDto.Parametrs.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForPath(entityDto => entityDto.Parametrs.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize))
                .ForPath(entityDto => entityDto.Parametrs.Membership,
                    opt => opt.MapFrom(entity => entity.MembershipId))
                .ForPath(entityDto => entityDto.Parametrs.ClassMember,
                    opt => opt.MapFrom(entity => entity.ClassMemberId))
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
