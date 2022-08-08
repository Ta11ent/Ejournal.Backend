using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberList
{
    public class GroupMemberLookupDto : IMapWith<StudentGroupMember>
    {
        public Guid ClassMemberId { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentGroupMember, GroupMemberLookupDto>()
                 .ForMember(entityDto => entityDto.ClassMemberId,
                     opt => opt.MapFrom(entity => entity.StudentGroupMemberId))
                 .ForMember(entityDto => entityDto.UserId,
                     opt => opt.MapFrom(entity => entity.UserId))
                 .ForMember(entityDto => entityDto.FirstName,
                     opt => opt.MapFrom(entity => entity.User.FirstName))
                 .ForMember(entityDto => entityDto.MiddleName,
                     opt => opt.MapFrom(entity => entity.User.MiddleName))
                 .ForMember(entityDto => entityDto.LastName,
                     opt => opt.MapFrom(entity => entity.User.LastName))
                 .ForMember(entityDto => entityDto.Gender,
                     opt => opt.MapFrom(entity => entity.User.Gender));
        }
    }
}
