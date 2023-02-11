using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList
{
    public class DepartmentMemberLookupDto : IMapWith<DepartmentMember>
    {
        public Guid MembershipId { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepartmentMember, DepartmentMemberLookupDto>()
                .ForMember(entityDto => entityDto.MembershipId,
                    opt => opt.MapFrom(entity => entity.DepartmentMemberId))
                .ForMember(entityDto => entityDto.UserId,
                    opt => opt.MapFrom(entity => entity.User.UserId))
                .ForMember(entityDto => entityDto.FirstName,
                    opt => opt.MapFrom(entity => entity.User.FirstName))
                .ForMember(entityDto => entityDto.MiddleName,
                    opt => opt.MapFrom(entity => entity.User.MiddleName))
                .ForMember(entityDto => entityDto.LastName,
                    opt => opt.MapFrom(entity => entity.User.LastName))
                .ForMember(entityDto => entityDto.Gender,
                    opt => opt.MapFrom(entity => entity.User.Gender))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
