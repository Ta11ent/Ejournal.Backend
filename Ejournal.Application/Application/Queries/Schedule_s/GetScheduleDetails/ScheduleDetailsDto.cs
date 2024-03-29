﻿using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ejournal.Application.Application.Queries.Schedule_s.GetScheduleDetails
{
    public  class ScheduleDetailsDto : IMapWith<Schedule>
    {
        public Guid ScheduleId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public GroupDto Group { get; set; }
        public string Part { get; set; }
        public List<ScheduleDayDto> ScheduleDays { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Schedule, ScheduleDetailsDto>()
                .ForMember(entityDto => entityDto.ScheduleId,
                    opt => opt.MapFrom(entity => entity.ScheduleId))
                 .ForMember(entityDto => entityDto.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                 .ForMember(entityDto => entityDto.Date,
                    opt => opt.MapFrom(entity => entity.Date))
                 .ForMember(entityDto => entityDto.Group,
                    opt => opt.MapFrom(entity => entity.StudentGroup))
                 .ForMember(entityDto => entityDto.Part,
                    opt => opt.MapFrom(entity => entity.Part.Name))
                 .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active))
                 .ForMember(entityDto => entityDto.ScheduleDays,
                    opt => opt.MapFrom(entity => entity.ScheduleDays
                        .OrderBy(x => x.Day)));
        }
    }

    public class ScheduleDayDto : IMapWith<ScheduleDay>
    {
        public string ScheduleDayId { get; set; }
        public DayOfWeek Day { get; set; }
        public List<SubjectDto> DaySubjects { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<ScheduleDay, ScheduleDayDto>()
                .ForMember(entityDto => entityDto.ScheduleDayId,
                    opt => opt.MapFrom(entity => entity.ScheduleDayId))
                 .ForMember(entityDto => entityDto.Day,
                    opt => opt.MapFrom(entity => entity.Day))
                 .ForMember(entityDto => entityDto.DaySubjects,
                    opt => opt.MapFrom(entity => entity.ScheduleSubjects
                        .OrderBy(x => x.Order)));
        }
    }
    public class SubjectDto : IMapWith<ScheduleSubject>
    {
        public Guid ScheduleSubjectId { get; set; }
        public Guid SubjectId { get; set; }
        public string Subject { get; set; }
        public string Professor { get; set; }
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
                 .ForMember(entityDto => entityDto.Professor,
                    opt => opt.MapFrom(entity => 
                        $"{entity.DepartmentMember.User.LastName} {entity.DepartmentMember.User.MiddleName} {entity.DepartmentMember.User.FirstName}"))
                 .ForMember(entityDto => entityDto.Order,
                    opt => opt.MapFrom(entity => entity.Order))
                  .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
    public class GroupDto : IMapWith<StudentGroup>
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentGroup, GroupDto>()
                .ForMember(entityDto => entityDto.GroupId,
                    opt => opt.MapFrom(entity => entity.StudentGroupId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name));
        }
    }
}
