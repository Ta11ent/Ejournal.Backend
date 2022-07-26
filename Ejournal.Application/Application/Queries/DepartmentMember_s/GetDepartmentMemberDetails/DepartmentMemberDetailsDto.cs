using AutoMapper;
using Ejournal.Application.Application.Queries.User_s.GetUserDetails;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Ejournal.Queries.Department_s.GetDeparmentDetails;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberDetails
{
    public class DepartmentMemberDetailsDto : IMapWith<DepartmentMember>
    {
        public Guid DepartmentMemberId { get; set; }
        public UserDetailsVm Professor { get; set; }
        public DepartmentDetails Department { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<DepartmentMember, DepartmentMemberDetailsDto>()
                .ForMember(entityVm => entityVm.DepartmentMemberId,
                    opt => opt.MapFrom(entity => entity.DepartmentMemberId))
                .ForMember(entityVm => entityVm.Department,
                    opt => opt.MapFrom(entity => entity.Department));
        }
    }

    public class DepartmentDetails : IMapWith<Department>
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentDetailsDto>()
                .ForMember(entityVm => entityVm.DepartmentId,
                    opt => opt.MapFrom(entity => entity.DepartmentId))
                .ForMember(entityVm => entityVm.Name,
                    opt => opt.MapFrom(entity => entity.Name));
        }
    }
}
