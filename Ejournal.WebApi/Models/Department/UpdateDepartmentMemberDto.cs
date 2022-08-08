using AutoMapper;
using Ejournal.Application.Application.Command.DepartmentMember_s.UpdateDepartmentMember;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Department
{
    public class UpdateDepartmentMemberDto : IMapWith<UpdateDepartmentMemberCommand>
    {
        public Guid MembershipId { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid UserId { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateDepartmentMemberDto, UpdateDepartmentMemberCommand>()
                .ForMember(entityDto => entityDto.DepartmentId,
                    opt => opt.MapFrom(entity => entity.DepartmentId))
                .ForMember(entityDto => entityDto.MembershipId,
                    opt => opt.MapFrom(entity => entity.MembershipId))
                .ForMember(entityDto => entityDto.UserId,
                    opt => opt.MapFrom(entity => entity.UserId))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
