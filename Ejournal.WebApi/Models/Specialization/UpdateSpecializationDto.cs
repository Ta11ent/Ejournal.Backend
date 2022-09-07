using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Ejournal.Command.Specialization_s.UpdateSpecialization;
using System;

namespace Ejournal.WebApi.Models.Specialization
{
    public class UpdateSpecializationDto : IMapWith<UpdateSpecializationCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSpecializationDto, UpdateSpecializationCommand>()
                .ForMember(entityCommand => entityCommand.Name,
                    opt => opt.MapFrom(entityDto => entityDto.Name))
                .ForMember(entityCommand => entityCommand.Description,
                    opt => opt.MapFrom(entityDto => entityDto.Description))
                .ForMember(entityCommand => entityCommand.Active,
                    opt => opt.MapFrom(entityDto => entityDto.Active));
        }
    }
}
