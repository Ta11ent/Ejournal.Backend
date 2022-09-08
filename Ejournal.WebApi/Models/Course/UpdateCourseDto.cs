using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Ejournal.Command.Course_s.UpdateCourse;

namespace Ejournal.WebApi.Models.Course
{
    public class UpdateCourseDto : IMapWith<UpdateCourseCommand>
    {
        public string Name { get; set; }
        public bool Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCourseDto, UpdateCourseCommand>()
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                 .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));

        }
    }
}
