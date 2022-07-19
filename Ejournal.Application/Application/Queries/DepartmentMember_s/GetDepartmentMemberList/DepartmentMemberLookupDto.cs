using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Ejournal.Queries.Department_s.GetDepartmentList;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList
{
    public class DepartmentMemberLookupDto : IMapWith<DepartmentMember>
    {
        public Guid DepartmenMemberId { get; set; }
        public Guid ProfessorId { get; set; }
        public DepartmentLookupDto Department { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepartmentMember, DepartmentMemberLookupDto>()
                .ForMember(entityDto => entityDto.DepartmenMemberId,
                    opt => opt.MapFrom(entity => entity.DepartmentMemberId))
                .ForMember(entityDto => entityDto.ProfessorId,
                    opt => opt.MapFrom(entity => entity.ProfessorId));
        }
    }
}
