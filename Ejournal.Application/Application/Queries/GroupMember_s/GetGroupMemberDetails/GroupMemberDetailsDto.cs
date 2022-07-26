using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;


namespace Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberDetails
{
    public class GroupMemberDetailsDto : IMapWith<StudentGroupMember>
    {
        public Guid GroupMemberId { get; set; }
        public Group Group { get; set; }
        public GroupMember Student { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<StudentGroupMember, GroupMemberDetailsDto>()
                 .ForMember(entityDto => entityDto.GroupMemberId,
                     opt => opt.MapFrom(entity => entity.StudentGroupMemberId))
                 .ForMember(entityDto => entityDto.Group,
                     opt => opt.MapFrom(entity => entity.StudentGroup));
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

    public class GroupMember : IMapWith<AspNetUser>
    {
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AspNetUser, GroupMember>()
                 .ForMember(entityDto => entityDto.StudentId,
                     opt => opt.MapFrom(entity => entity.Id))
                 .ForMember(entityDto => entityDto.FirstName,
                     opt => opt.MapFrom(entity => entity.FirstName))
                 .ForMember(entityDto => entityDto.MiddleName,
                     opt => opt.MapFrom(entity => entity.MiddleName))
                 .ForMember(entityDto => entityDto.LastName,
                     opt => opt.MapFrom(entity => entity.LastName))
                 .ForMember(entityDto => entityDto.Email,
                     opt => opt.MapFrom(entity => entity.Email))
                 .ForMember(entityDto => entityDto.PhoneNumber,
                     opt => opt.MapFrom(entity => entity.PhoneNumber));
        }
    }
}
