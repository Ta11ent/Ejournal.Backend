using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupDetails
{
    public class GroupDetailsDto : IMapWith<StudentGroup>
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
        public GroupSpecializationDto Specialization { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentGroup, GroupDetailsDto>()
                .ForMember(entityDto => entityDto.GroupId,
                    opt => opt.MapFrom(entity => entity.StudentGroupId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityDto => entityDto.StartDate,
                    opt => opt.MapFrom(entity => entity.StartDate))
                .ForMember(entityDto => entityDto.EndDate,
                    opt => opt.MapFrom(entity => entity.EndDate))
                .ForMember(entityDto => entityDto.Specialization,
                    opt => opt.MapFrom(entity => entity.Specialization));
        }
    }
}
