using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Ejournal.Queries.Curriculum_s.GetCurriculumDetails
{
    public class CurriculumDetailsVm : IMapWith<Curriculum>
    {
        public Guid CurriculumId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid SpecializationId { get; set; }
        public Guid CourseId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Curriculum, CurriculumDetailsVm>()
                .ForMember(entityVm => entityVm.CurriculumId,
                    opt => opt.MapFrom(entity => entity.CurriculumId))
                .ForMember(entityVm => entityVm.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityVm => entityVm.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(entityVm => entityVm.SpecializationId,
                    opt => opt.MapFrom(entity => entity.SpecializationId))
                .ForMember(entityVm => entityVm.CourseId,
                    opt => opt.MapFrom(entity => entity.CourseId));
        }
    }
}
