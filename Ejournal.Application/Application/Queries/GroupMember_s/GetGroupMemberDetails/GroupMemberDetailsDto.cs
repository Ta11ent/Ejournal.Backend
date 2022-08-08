using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;


namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberDetails
{
    public class GroupMemberDetailsDto : IMapWith<StudentGroupMember>
    {
        public Guid ClassMemberId { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public Group Group { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentGroupMember, GroupMemberDetailsDto>()
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
                     opt => opt.MapFrom(entity => entity.User.Gender))
                 .ForMember(entityDto => entityDto.Group,
                     opt => opt.MapFrom(entity => entity.StudentGroup))
                 .ForMember(entityDto => entityDto.Active,
                     opt => opt.MapFrom(entity => entity.Active));
        }
    }

    public class Group : IMapWith<StudentGroup>
    {
        public Guid GroupId { get; set; }
        public string Name { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentGroup, Group>()
                 .ForMember(entityDto => entityDto.GroupId,
                     opt => opt.MapFrom(entity => entity.StudentGroupId))
                 .ForMember(entityDto => entityDto.Name,
                     opt => opt.MapFrom(entity => entity.Name));
        }
    }
}
