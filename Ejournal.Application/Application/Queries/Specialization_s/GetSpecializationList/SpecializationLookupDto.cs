using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationList
{
    public class SpecializationLookupDto : IMapWith<Specialization>
    {
        public Guid SpecializationId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Specialization, SpecializationLookupDto>()
                .ForMember(entityDto => entityDto.SpecializationId,
                    opt => opt.MapFrom(entity => entity.SpecializationId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
