using AutoMapper;
using Ejournal.Application.Application.Command.Schedule_s.CreateSchedule;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Schedule
{
    public class CreateScheduleDto : IMapWith<CreateScheduleCommmand>
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Guid GroupId { get; set; }
        public Guid PartId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateScheduleDto, CreateScheduleCommmand>()
                .ForMember(entiityDto => entiityDto.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(entiityDto => entiityDto.Date,
                    opt => opt.MapFrom(entity => entity.Date))
                .ForMember(entiityDto => entiityDto.GroupId,
                    opt => opt.MapFrom(entity => entity.GroupId))
                .ForMember(entiityDto => entiityDto.PartId,
                    opt => opt.MapFrom(entity => entity.PartId));
        }
        
    }
}
