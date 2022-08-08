using AutoMapper;
using Ejournal.Application.Application.Command.RatingLog_s.CreateRatingLog;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.RatingLog
{
    public class CreateRatingLogDto : IMapWith<CreateRatingLogCommand>
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid SubjectId { get; set; }
        public Guid MarkId { get; set; }
        public Guid GroupMemberId { get; set; }
        public Guid DepartmentMemberId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRatingLogDto, CreateRatingLogCommand>()
                .ForMember(entityDto => entityDto.Date,
                    opt => opt.MapFrom(entiity => entiity.Date))
                .ForMember(entityDto => entityDto.Description,
                    opt => opt.MapFrom(entiity => entiity.Description))
                .ForMember(entityDto => entityDto.SubjectId,
                    opt => opt.MapFrom(entiity => entiity.SubjectId))
                .ForMember(entityDto => entityDto.MarkId,
                    opt => opt.MapFrom(entiity => entiity.MarkId))
                .ForMember(entityDto => entityDto.GroupMemberId,
                    opt => opt.MapFrom(entiity => entiity.GroupMemberId))
                .ForMember(entityDto => entityDto.DepartmentMemberId,
                    opt => opt.MapFrom(entiity => entiity.DepartmentMemberId));
        }
    }
}
