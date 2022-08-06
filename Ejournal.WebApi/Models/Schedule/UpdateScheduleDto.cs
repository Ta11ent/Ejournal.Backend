using AutoMapper;
using Ejournal.Application.Application.Command.Schedule_s.UpdateSchedule;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Schedule
{
    public class UpdateScheduleDto : IMapWith<UpdateScheduleCommand>
    {
        public Guid ScheduleId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid GroupId { get; set; }
        public Guid PartId { get; set; }
        public bool Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateScheduleDto, UpdateScheduleCommand>()
                .ForMember(entiityDto => entiityDto.ScheduleId,
                    opt => opt.MapFrom(entity => entity.ScheduleId))
                .ForMember(entiityDto => entiityDto.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(entiityDto => entiityDto.Date,
                    opt => opt.MapFrom(entity => entity.Date))
                .ForMember(entiityDto => entiityDto.GroupId,
                    opt => opt.MapFrom(entity => entity.GroupId))
                .ForMember(entiityDto => entiityDto.PartId,
                    opt => opt.MapFrom(entity => entity.PartId))
                .ForMember(entiityDto => entiityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
