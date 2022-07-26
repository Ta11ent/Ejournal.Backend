using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberList
{
    public class DepartmentMemberLookupDto : IMapWith<DepartmentMember>
    {
        public Guid DepartmenMemberId { get; set; }
        public ProfessorDto Professor { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepartmentMember, DepartmentMemberLookupDto>()
                .ForMember(entityDto => entityDto.DepartmenMemberId,
                    opt => opt.MapFrom(entity => entity.DepartmentMemberId));
        }
    }

    public class ProfessorDto : IMapWith<AspNetUser>
    {
        public Guid ProfessorId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<AspNetUser, ProfessorDto>()
                .ForMember(entityDto => entityDto.ProfessorId,
                    opt => opt.MapFrom(entity => entity.Id))
                 .ForMember(entityDto => entityDto.FirstName,
                    opt => opt.MapFrom(entity => entity.FirstName))
                  .ForMember(entityDto => entityDto.MiddleName,
                    opt => opt.MapFrom(entity => entity.MiddleName))
                   .ForMember(entityDto => entityDto.LastName,
                    opt => opt.MapFrom(entity => entity.LastName));

        }
    }
}
