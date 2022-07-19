using AutoMapper;
using Ejournal.Application.Application.Queries.User_s.GetUserDetails;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Ejournal.Queries.Department_s.GetDeparmentDetails;
using Ejournal.Domain;
using System;
using System.Collections.Generic;

namespace Ejournal.Application.Application.Queries.DepartmentMember_s.GetDepartmentMemberDetails
{
    public class DepartmentMemberDetailsDto : IMapWith<DepartmentMember>
    {
        public Guid DepartmentMemberId { get; set; }
        //public Guid PrfessorId { get; set; }
        public UserDetailsVm Professor { get; set; }
        public DepartmentDetailsDto Department { get; set; }
        public void Mapping (Profile profile)
        {
            profile.CreateMap<DepartmentMember, DepartmentMemberDetailsDto>()
                .ForMember(entityVm => entityVm.DepartmentMemberId, 
                    opt => opt.MapFrom(entity => entity.DepartmentMemberId))
                //.ForMember(entityVm => entityVm.PrfessorId,
                //    opt => opt.MapFrom(entity => entity.ProfessorId))
                .ForMember(entityVm => entityVm.Department,
                    opt => opt.MapFrom(entity => entity.Department));
        }
    }
}
