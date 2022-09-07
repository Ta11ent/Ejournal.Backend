using AutoMapper;
using Ejournal.Application.Application.Command.Subject_s.UpdateSubject;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Subject
{
    public class UpdateSubjectDto : IMapWith<UpdateSubjectCommand>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid DepartmentId { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateSubjectDto, UpdateSubjectCommand>()
                .ForMember(entityCommand => entityCommand.Name,
                    opt => opt.MapFrom(entityDto => entityDto.Name))
                .ForMember(entityCommand => entityCommand.Description,
                    opt => opt.MapFrom(entityDto => entityDto.Description))
                .ForMember(entityCommand => entityCommand.DepartmentId,
                    opt => opt.MapFrom(entityDto => entityDto.DepartmentId))
                .ForMember(entityCommand => entityCommand.Active,
                    opt => opt.MapFrom(entityDto => entityDto.Active));
        }
    }
}
