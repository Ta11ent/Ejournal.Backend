using AutoMapper;
using Ejournal.Application.Application.Command.DepartmentMember_s.CreateDepartmetMember;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models
{
    public class CreateDeartmentMemberDto : IMapWith<CreateDepartmentMemberCommand>
    {
        public Guid ProfessorId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateDeartmentMemberDto, CreateDepartmentMemberCommand>()
                .ForMember(entityCommnd => entityCommnd.ProfessorId,
                    opt => opt.MapFrom(entity => entity.ProfessorId));
        }
    }
}
