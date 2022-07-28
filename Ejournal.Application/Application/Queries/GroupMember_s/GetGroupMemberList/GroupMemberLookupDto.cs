using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberList
{
    public class GroupMemberLookupDto : IMapWith<StudentGroupMember>
    {
        public Guid GroupMemberId { get; set; }
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentGroupMember, GroupMemberLookupDto>()
                 .ForMember(entityDto => entityDto.GroupMemberId,
                     opt => opt.MapFrom(entity => entity.StudentGroupMemberId))
                 .ForMember(entityDto => entityDto.StudentId,
                     opt => opt.MapFrom(entity => entity.StudentId))
                 .ForMember(entityDto => entityDto.FirstName,
                     opt => opt.MapFrom(entity => entity.Student.FirstName))
                 .ForMember(entityDto => entityDto.MiddleName,
                     opt => opt.MapFrom(entity => entity.Student.MiddleName))
                 .ForMember(entityDto => entityDto.LastName,
                     opt => opt.MapFrom(entity => entity.Student.LastName))
                 .ForMember(entityDto => entityDto.Gender,
                     opt => opt.MapFrom(entity => entity.Student.Gender));
        }
    }
}
