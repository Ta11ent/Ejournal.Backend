using AutoMapper;
using Ejournal.Application.Application.Command.ScheduleDay_s.CreateCheduleDate;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.ScheduleDay
{
    internal class CreateScheduleDayDto : IMapWith<CreateScheduleDayCommand>
    {
        internal DayOfWeek Day { get; set; }
        internal Guid ScheuleId { get; set; }
        internal void Mapping (Profile profile)
        {
            profile.CreateMap<CreateScheduleDayDto, CreateScheduleDayCommand>()
                .ForMember(entityDto => entityDto.Day,
                    opt => opt.MapFrom(entity => entity.Day))
                .ForMember(entityDto => entityDto.ScheduleId,
                    opt => opt.MapFrom(entity => entity.ScheuleId));
        }
    }

}
