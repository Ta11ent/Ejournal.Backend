using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.Part_s.GetPartDetails
{
    public class PartDetailsDto : IMapWith<Part>
    {
        public Guid PartId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate {get;set;}
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Part, PartDetailsDto>()
                .ForMember(entityDto => entityDto.PartId,
                    opt => opt.MapFrom(entity => entity.PartId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityDto => entityDto.StartDate,
                    opt => opt.MapFrom(entity => entity.StartDate))
                .ForMember(entityDto => entityDto.EndDate,
                    opt => opt.MapFrom(entity => entity.EndDate))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
