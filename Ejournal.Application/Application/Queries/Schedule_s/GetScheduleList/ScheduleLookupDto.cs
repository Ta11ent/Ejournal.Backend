﻿using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.Schedule_s.GetScheduleList
{
    public class ScheduleLookupDto : IMapWith<Schedule>
    {
        public Guid ScheduleId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Schedule, ScheduleLookupDto>()
                .ForMember(enttiy => enttiy.ScheduleId,
                    opt => opt.MapFrom(entity => entity.ScheduleId))
                .ForMember(enttiy => enttiy.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(enttiy => enttiy.Date,
                    opt => opt.MapFrom(entity => entity.Date));
        }
    }
}
