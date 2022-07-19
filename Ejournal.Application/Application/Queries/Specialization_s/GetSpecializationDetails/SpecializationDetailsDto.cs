using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationDetails
{
    public class SpecializationDetailsDto : IMapWith<Specialization>
    {
        public Guid SpecializationId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Specialization, SpecializationDetailsDto>()
                .ForMember(entityVm => entityVm.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityVm => entityVm.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(entityVm => entityVm.CreationDate,
                    opt => opt.MapFrom(entity => entity.CreationDate));
        }
    }
}
