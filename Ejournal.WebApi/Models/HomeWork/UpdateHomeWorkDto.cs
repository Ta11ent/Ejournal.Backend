using AutoMapper;
using Ejournal.Application.Application.Command.HomeWork_s.UpdateHomeWork;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.HomeWork
{
    public class UpdateHomeWorkDto : IMapWith<UpdateHomeWorkCommand>
    {
        public Guid HomeWorkId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public Guid GroupId { get; set; }
        public Guid SubjectId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateHomeWorkDto, UpdateHomeWorkCommand>()
                .ForMember(entityCommand => entityCommand.HomeWorkId,
                    opt => opt.MapFrom(entityDto => entityDto.HomeWorkId))
                .ForMember(entityCommand => entityCommand.Date,
                    opt => opt.MapFrom(entityDto => entityDto.Date))
                .ForMember(entityCommand => entityCommand.Description,
                    opt => opt.MapFrom(entityDto => entityDto.Description))
                .ForMember(entityCommand => entityCommand.GroupId,
                    opt => opt.MapFrom(entityDto => entityDto.GroupId))
                .ForMember(entityCommand => entityCommand.SubjectId,
                    opt => opt.MapFrom(entityDto => entityDto.SubjectId));
        }
    }
}
