using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Ejournal.Queries.Сourse_s.GetCourseList
{
    public class CourseLookupDto : IMapWith<Course>
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Course, CourseLookupDto>()
                .ForMember(entityDto => entityDto.CourseId,
                    opt => opt.MapFrom(entity => entity.CourseId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
