using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberDetails
{
    public class DepartmentMemberDetailsDto : IMapWith<DepartmentMember>
    {
        public Guid MembershipId { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DepartmentDto Department { get; set; }
        public bool Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepartmentMember, DepartmentMemberDetailsDto>()
                .ForMember(entityVm => entityVm.MembershipId,
                    opt => opt.MapFrom(entity => entity.DepartmentMemberId))
                .ForMember(entityVm => entityVm.UserId,
                    opt => opt.MapFrom(entity => entity.User.UserId))
                .ForMember(entityVm => entityVm.FirstName,
                    opt => opt.MapFrom(entity => entity.User.FirstName))
                .ForMember(entityVm => entityVm.MiddleName,
                    opt => opt.MapFrom(entity => entity.User.MiddleName))
                .ForMember(entityVm => entityVm.LastName,
                    opt => opt.MapFrom(entity => entity.User.LastName))
                .ForMember(entityVm => entityVm.Department,
                    opt => opt.MapFrom(entity => entity.Department))
                 .ForMember(entityVm => entityVm.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
       
    }

    public class DepartmentDto : IMapWith<Department>
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentDto>()
                .ForMember(entityVm => entityVm.DepartmentId,
                    opt => opt.MapFrom(entity => entity.DepartmentId))
                .ForMember(entityVm => entityVm.Name,
                    opt => opt.MapFrom(entity => entity.Name));
        }
    }
}
