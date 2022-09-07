using AutoMapper;
using Ejournal.Application.Application.Command.GroupMember.UpdateGroupMember;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.Group
{
    public class UpdateGroupMemberDto : IMapWith<UpdateGroupMemberCommand>
    {
        public Guid UserId { get; set; }
        public bool Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGroupMemberDto, UpdateGroupMemberCommand>()
                .ForMember(entityDto => entityDto.UserId,
                    opt => opt.MapFrom(entity => entity.UserId))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
