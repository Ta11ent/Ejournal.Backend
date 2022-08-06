using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.ScheduleSubject_s.GetScheduleSubjectDetails
{
    public class ScheduleSubjectDetailsDto : IMapWith<ScheduleSubject>
    {
        public Guid ScheduleSubjectId { get; set; }
        public DayOfWeek Day { get; set; }
        public int Order { get; set; }
        public SubjectDto Subject { get; set; }
        public ProfessorDto Professor { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ScheduleSubject, ScheduleSubjectDetailsDto>()
                 .ForMember(entityDto => entityDto.ScheduleSubjectId,
                    opt => opt.MapFrom(entity => entity.ScheduleSubjectId))
                 .ForMember(entityDto => entityDto.Day,
                    opt => opt.MapFrom(entity => entity.ScheduleDay.Day))
                 .ForMember(entityDto => entityDto.Order,
                    opt => opt.MapFrom(entity => entity.Order))
                 .ForMember(entityDto => entityDto.Subject,
                    opt => opt.MapFrom(entity => entity.Subject))
                 .ForMember(entityDto => entityDto.Professor,
                    opt => opt.MapFrom(entity => entity.DepartmentMember))
                 .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }

    }

    public class ProfessorDto : IMapWith<DepartmentMember>
    {
        public Guid ProfessorId { get; set; }
        public string FullName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepartmentMember, ProfessorDto>()
                 .ForMember(entityDto => entityDto.ProfessorId,
                    opt => opt.MapFrom(entity => entity.DepartmentMemberId))
                .ForMember(entityDto => entityDto.FullName,
                    opt => opt.MapFrom(entity =>
                        $"{entity.Professor.LastName} {entity.Professor.MiddleName} {entity.Professor.FirstName}"));
        }
    }
    public class SubjectDto : IMapWith<Subject>
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subject, SubjectDto>()
                 .ForMember(entityDto => entityDto.SubjectId,
                    opt => opt.MapFrom(entity => entity.SubjectId))
                 .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name));
        }
    }
}
