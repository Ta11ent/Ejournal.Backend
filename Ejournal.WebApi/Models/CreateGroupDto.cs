using AutoMapper;
using Ejournal.Application.Application.Command.Goup_s.CreateGroup;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models
{
    public class CreateGroupDto : IMapWith<CreateGroupCommand>
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid SpecializationId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGroupDto, CreateGroupCommand>()
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityDto => entityDto.StartDate,
                    opt => opt.MapFrom(entity => entity.StartDate))
                .ForMember(entityDto => entityDto.EndDate,
                    opt => opt.MapFrom(entity => entity.EndDate))
                .ForMember(entityDto => entityDto.SpecializationId,
                    opt => opt.MapFrom(entity => entity.SpecializationId));

        }
    }
}
