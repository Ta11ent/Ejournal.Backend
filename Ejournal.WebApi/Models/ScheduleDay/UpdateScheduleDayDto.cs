using AutoMapper;
using Ejournal.Application.Application.Command.ScheduleDate_s.UpdateScheduleDate;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.ScheduleDay
{
    internal class UpdateScheduleDayDto : IMapWith<UpdateSchduleDayCommand>
    {
        internal DayOfWeek Day { get; set; }
        internal bool Active { get; set; }
        internal void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateScheduleDayDto, UpdateSchduleDayCommand>()
                .ForMember(entityDto => entityDto.Day,
                    opt => opt.MapFrom(entity => entity.Day))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
