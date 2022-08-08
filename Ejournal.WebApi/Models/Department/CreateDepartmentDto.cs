using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Ejournal.Command.Department_s.CreateDepartment;

namespace Ejournal.WebApi.Models.Department
{
    public class CreateDepartmentDto : IMapWith<CreateDepartmentCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDepartmentDto, CreateDepartmentCommand>()
                .ForMember(entityCommand => entityCommand.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityCommand => entityCommand.Description,
                    opt => opt.MapFrom(entity => entity.Description));
        }
    }
}
