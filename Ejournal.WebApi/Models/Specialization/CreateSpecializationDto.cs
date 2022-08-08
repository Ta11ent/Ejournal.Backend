using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Ejournal.Command.Specialization_s.CreateSpecialization;

namespace Ejournal.WebApi.Models.Specialization
{
    public class CreateSpecializationDto : IMapWith<CreateSpecializationCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSpecializationDto, CreateSpecializationCommand>()
                .ForMember(entityCommand => entityCommand.Name,
                    opt => opt.MapFrom(entityDto => entityDto.Name))
                .ForMember(entityCommand => entityCommand.Description,
                    opt => opt.MapFrom(entityDto => entityDto.Description));
        }
    }
}
