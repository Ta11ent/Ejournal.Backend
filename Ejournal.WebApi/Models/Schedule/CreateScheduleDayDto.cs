using AutoMapper;
using Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDate;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Schedule
{
    public class CreateScheduleDayDto : IMapWith<CreateScheduleDayCommand>
    {
        public int Day { get; set; }
        public Guid ScheuleId { get; set; }
        public void Mapping (Profile profile)
        {
            profile.CreateMap<CreateScheduleDayDto, CreateScheduleDayCommand>()
                .ForMember(entityDto => entityDto.Day,
                    opt => opt.MapFrom(entity => entity.Day))
                .ForMember(entityDto => entityDto.ScheduleId,
                    opt => opt.MapFrom(entity => entity.ScheuleId));
        }
    }

}
