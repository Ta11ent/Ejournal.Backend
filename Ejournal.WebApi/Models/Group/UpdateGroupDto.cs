using AutoMapper;
using Ejournal.Application.Application.Command.Goup_s.UpdateGroup;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Group
{
    public class UpdateGroupDto : IMapWith<UpdateGroupCommand>
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid SpecializationId { get; set; }
        public bool Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGroupDto, UpdateGroupCommand>()
                .ForMember(entityDto => entityDto.GroupId,
                    opt => opt.MapFrom(entity => entity.GroupId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityDto => entityDto.StartDate,
                    opt => opt.MapFrom(entity => entity.StartDate))
                .ForMember(entityDto => entityDto.EndDate,
                    opt => opt.MapFrom(entity => entity.EndDate))
                .ForMember(entityDto => entityDto.SpecializationId,
                    opt => opt.MapFrom(entity => entity.SpecializationId))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));

        }
    }
}
