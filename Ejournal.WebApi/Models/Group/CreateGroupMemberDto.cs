using AutoMapper;
using Ejournal.Application.Application.Command.GroupMember.CreateGroupMember;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Group
{
    public class CreateGroupMemberDto : IMapWith<CreateGroupMemberCommand>
    {
        public Guid UserId { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGroupMemberDto, CreateGroupMemberCommand>()
                .ForMember(entityDto => entityDto.UserId,
                    opt => opt.MapFrom(entity => entity.UserId));
        }
    }
}
