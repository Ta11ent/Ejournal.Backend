using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Ejournal.Queries.Specialization_s.GetSpecializationList;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.Goup_s.GetGroupList
{
    public class GroupLookupDto : IMapWith<StudentGroup>
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public SpecializationLookupDto Specialization { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentGroup, GroupLookupDto>()
                .ForMember(entityDto => entityDto.GroupId,
                    opt => opt.MapFrom(entity => entity.StudentGroupId))
                .ForMember(entityDto => entityDto.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityDto => entityDto.Specialization,
                    opt => opt.MapFrom(entity => entity.Specialization));
        }
    }   
}
