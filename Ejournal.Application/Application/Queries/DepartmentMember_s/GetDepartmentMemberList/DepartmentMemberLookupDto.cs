using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList
{
    public class DepartmentMemberLookupDto : IMapWith<DepartmentMember>
    {
        public Guid DepartmenMemberId { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepartmentMember, DepartmentMemberLookupDto>()
                .ForMember(entityDto => entityDto.DepartmenMemberId,
                    opt => opt.MapFrom(entity => entity.DepartmentMemberId))
                .ForMember(entityDto => entityDto.FirstName,
                    opt => opt.MapFrom(entity => entity.Professor.FirstName))
                .ForMember(entityDto => entityDto.MiddleName,
                    opt => opt.MapFrom(entity => entity.Professor.MiddleName))
                .ForMember(entityDto => entityDto.LastName,
                    opt => opt.MapFrom(entity => entity.Professor.LastName))
        }
    }
}
