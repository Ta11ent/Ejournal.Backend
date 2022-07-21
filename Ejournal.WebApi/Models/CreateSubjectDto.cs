using AutoMapper;
using Ejournal.Application.Application.Command.Subject_s.CreateSubject;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models
{
    public class CreateSubjectDto : IMapWith<CreateSubjectCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateSubjectDto, CreateSubjectCommand>()
                .ForMember(entityCommand => entityCommand.Name,
                    opt => opt.MapFrom(entityDto => entityDto.Name))
                .ForMember(entityCommand => entityCommand.Description,
                    opt => opt.MapFrom(entityDto => entityDto.Description))
                .ForMember(entityCommand => entityCommand.DepartmentId,
                    opt => opt.MapFrom(entityDto => entityDto.DepartmentId));
        }
    }
}
