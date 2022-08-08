using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Ejournal.Command.Course_s.UpdateCourse;
using System;

namespace Ejournal.WebApi.Models.Course
{
    public class UpdateCourseDto : IMapWith<UpdateCourseCommand>
    {
        public Guid CourseId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCourseDto, UpdateCourseCommand>()
                .ForMember(entityDto => entityDto.CourseId,
                    opt => opt.MapFrom(entity => entity.CourseId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                 .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));

        }
    }
}
