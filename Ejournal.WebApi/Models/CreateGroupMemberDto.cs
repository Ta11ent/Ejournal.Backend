using AutoMapper;
using Ejournal.Application.Application.Command.GroupMember.CreateGroupMember;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models
{
    public class CreateGroupMemberDto : IMapWith<CreateGroupMemberCommand>
    {
        public Guid StudentId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGroupMemberDto, CreateGroupMemberCommand>()
                .ForMember(entityDto => entityDto.StudentId,
                    opt => opt.MapFrom(entity => entity.StudentId));
        }
    }
}
