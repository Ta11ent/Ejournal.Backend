using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.Part_s.GetPartList
{
    public class PartLookupDto : IMapWith<Part>
    {
        public Guid PartId { get; set; }
        public string Name { get; set; }
        public string Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Part, PartLookupDto>()
                .ForMember(entityDto => entityDto.PartId,
                    opt => opt.MapFrom(entity => entity.PartId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
