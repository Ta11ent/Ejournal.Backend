using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejournal.Application.Application.Queries.ScheduleDay_s.GetScheduleDayDetails
{
    public class ScheduleDayDetailsDto : IMapWith<ScheduleDay>
    {
        public Guid ScheduleDayId { get; set; }
        public DayOfWeek Day { get; set; }
        public List<SubjectDto> Subjects { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ScheduleDay, ScheduleDayDetailsDto>()
                .ForMember(entityDto => entityDto.ScheduleDayId,
                    opt => opt.MapFrom(entity => entity.ScheduleDayId))
                 .ForMember(entityDto => entityDto.Day,
                    opt => opt.MapFrom(entity => entity.Day))
                 .ForMember(entityDto => entityDto.Subjects,
                    opt => opt.MapFrom(entity => entity.ScheduleSubjects))
                 .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }

    public class SubjectDto : IMapWith<ScheduleSubject>
    {
        public Guid ScheduleSubjectId { get; set; }
        public Guid SubjectId { get; set; }
        public string Subject { get; set; }
        public int Order { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ScheduleSubject, SubjectDto>()
                .ForMember(entityDto => entityDto.ScheduleSubjectId,
                    opt => opt.MapFrom(entity => entity.ScheduleSubjectId))
                 .ForMember(entityDto => entityDto.SubjectId,
                    opt => opt.MapFrom(entity => entity.Subject.SubjectId))
                 .ForMember(entityDto => entityDto.Subject,
                    opt => opt.MapFrom(entity => entity.Subject.Name))
                 .ForMember(entityDto => entityDto.Order,
                    opt => opt.MapFrom(entity => entity.Order))
                  .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}