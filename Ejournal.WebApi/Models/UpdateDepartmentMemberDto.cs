using AutoMapper;
using Ejournal.Application.Application.Command.DepartmentMember_s.UpdateDepartmentMember;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models
{
    public class UpdateDepartmentMemberDto : IMapWith<UpdateDepartmentMemberCommand>
    {
        public Guid DepartmentMemberId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid ProfessorId { get; set; }
        public bool bActive { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDepartmentMemberDto, UpdateDepartmentMemberCommand>()
                .ForMember(entityDto => entityDto.DepartmentId,
                    opt => opt.MapFrom(entity => entity.DepartmentId))
                .ForMember(entityDto => entityDto.DepartmentMemberId,
                    opt => opt.MapFrom(entity => entity.DepartmentMemberId))
                .ForMember(entityDto => entityDto.ProfessorId,
                    opt => opt.MapFrom(entity => entity.ProfessorId))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.bActive));
        }
    }
}
