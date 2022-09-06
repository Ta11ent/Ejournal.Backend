using AutoMapper;
using Ejournal.Application.Application.Command.DepartmentMember_s.CreateDepartmetMember;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Department
{
    public class CreateDeartmentMemberDto : IMapWith<CreateDepartmentMemberCommand>
    {
        public Guid UserId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDeartmentMemberDto, CreateDepartmentMemberCommand>()
                .ForMember(entityCommnd => entityCommnd.UserId,
                    opt => opt.MapFrom(entity => entity.UserId));
        }
    }
}
