using AutoMapper;
using Ejournal.Application.Application.Command.Part_s.UpdatePart;
using Ejournal.Application.Common.Mappings;
using System;


namespace Ejournal.WebApi.Models.Part
{
    public class UpdatePartDto : IMapWith<UpdatePartCommand>
    {
        public Guid PartId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePartDto, UpdatePartCommand>()
                .ForMember(entityCommand => entityCommand.PartId,
                    opt => opt.MapFrom(entityDto => entityDto.PartId))
                .ForMember(entityCommand => entityCommand.Name,
                    opt => opt.MapFrom(entityDto => entityDto.Name))
                .ForMember(entityCommand => entityCommand.StartDate,
                    opt => opt.MapFrom(entityDto => entityDto.StartDate))
                .ForMember(entityCommand => entityCommand.EndDate,
                    opt => opt.MapFrom(entityDto => entityDto.EndDate));
        }
    }
}
