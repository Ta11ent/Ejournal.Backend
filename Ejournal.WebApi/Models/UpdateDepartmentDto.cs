using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Ejournal.Command.Department_s.UpdateDepartment;
using System;

namespace Ejournal.WebApi.Models
{
    public class UpdateDepartmentDto : IMapWith<UpdateDepartmentCommand>
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDepartmentDto, UpdateDepartmentCommand>()
                .ForMember(entityCommand => entityCommand.DepartmentId,
                    opt => opt.MapFrom(entity => entity.DepartmentId))
                .ForMember(entityCommand => entityCommand.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityCommand => entityCommand.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(entityCommand => entityCommand.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
