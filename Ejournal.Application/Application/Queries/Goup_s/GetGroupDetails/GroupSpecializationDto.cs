using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupDetails
{
    public class GroupSpecializationDto : IMapWith<Specialization>
    {
        public Guid SpecializationId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Specialization, GroupSpecializationDto>()
                .ForMember(entityDto => entityDto.SpecializationId,
                    opt => opt.MapFrom(entity => entity.SpecializationId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name));
        }
    }
}
