using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Ejournal.Queries.Department_s.GetDeparmentDetails
{
    public class DepartmentDetailsDto : IMapWith<Department>
    {
        public Guid DepartmentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Department, DepartmentDetailsDto>()
                .ForMember(entityVm => entityVm.DepartmentId,
                    opt => opt.MapFrom(entity => entity.DepartmentId))
                .ForMember(entityVm => entityVm.Name,
                    opt => opt.MapFrom(entity => entity.Name))
                .ForMember(entityVm => entityVm.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(entityVm => entityVm.Active,
                    opt => opt.MapFrom(entity => entity.Active));

        }
    }
}