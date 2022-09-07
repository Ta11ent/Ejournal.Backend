using AutoMapper;
using Ejournal.Application.Application.Command.ScheduleDay_s.UpdateScheduleDate;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Schedule
{
    public class UpdateScheduleDayDto : IMapWith<UpdateSchduleDayCommand>
    {
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateScheduleDayDto, UpdateSchduleDayCommand>()
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
