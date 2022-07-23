﻿using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.Mark_s.GetMarkDetails
{
    public class MarkDetailsDto : IMapWith<Mark>
    {
        public Guid MarkId { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Mark, MarkDetailsDto>()
                .ForMember(entityDto => entityDto.MarkId,
                    opt => opt.MapFrom(entity => entity.MarkId))
                 .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name));
        }
    }
}
