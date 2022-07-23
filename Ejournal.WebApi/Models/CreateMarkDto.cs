using AutoMapper;
using Ejournal.Application.Application.Command.Mark_s.CreateMark;
using Ejournal.Application.Common.Mappings;

namespace Ejournal.WebApi.Models
{
    public class CreateMarkDto : IMapWith<CreateMarkCommand>
    {
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateMarkDto, CreateMarkCommand>()
                .ForMember(entityCommand => entityCommand.Name,
                    opt => opt.MapFrom(entityDto => entityDto.Name));
        }
    }
}
