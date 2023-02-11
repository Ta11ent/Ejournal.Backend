using AutoMapper;
using Ejournal.Application.Application.Command.Mark_s.UpdateMark;
using Ejournal.Application.Common.Mappings;

namespace Ejournal.WebApi.Models.Mark
{
    public class UpdateMarkDto : IMapWith<UpdateMarkCommand>
    {
        public string Name { get; set; }
        public bool Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateMarkDto, UpdateMarkCommand>()
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));

        }
    }
}
