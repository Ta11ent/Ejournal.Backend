using AutoMapper;
using Ejournal.Application.Application.Command.Mark_s.CreateMark;
using Ejournal.Application.Application.Command.Mark_s.UpdateMark;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Mark
{
    public class UpdateMarkDto : IMapWith<CreateMarkCommand>
    {
        public Guid MarkId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMarkDto, UpdateMarkCommand>()
                .ForMember(entityDto => entityDto.MarkId,
                    opt => opt.MapFrom(entity => entity.MarkId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name));

        }
    }
}
