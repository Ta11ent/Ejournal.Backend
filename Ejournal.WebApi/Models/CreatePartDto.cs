using AutoMapper;
using Ejournal.Application.Application.Command.Part_s.CreatePart;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models
{
    public class CreatePartDto : IMapWith<CreatePartCommand>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePartDto, CreatePartCommand>()
                .ForMember(entityCommand => entityCommand.Name,
                    opt => opt.MapFrom(entityDto => entityDto.Name))
                .ForMember(entityCommand => entityCommand.StartDate,
                    opt => opt.MapFrom(entityDto => entityDto.StartDate))
                .ForMember(entityCommand => entityCommand.EndDate,
                    opt => opt.MapFrom(entityDto => entityDto.EndDate));
        }
    }
}
