using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.Part_s.Subject_s.GetSubjectDetails
{
    public class SubjectDetailsDto : IMapWith<Subject>
    {
        public Guid SubjectId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Department Department { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Subject, SubjectDetailsDto>()
                .ForMember(entityDto => entityDto.SubjectId,
                    opt => opt.MapFrom(entity => entity.SubjectId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityDto => entityDto.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(entityDto => entityDto.Department,
                    opt => opt.MapFrom(entity => entity.Department));
        }
    }
}
