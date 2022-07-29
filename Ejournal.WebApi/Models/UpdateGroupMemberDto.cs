using AutoMapper;
using Ejournal.Application.Application.Command.GroupMember.UpdateGroupMember;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models
{
    public class UpdateGroupMemberDto : IMapWith<UpdateGroupMemberCommand>
    {
        public Guid GroupMemberId { get; set; }
        public Guid GroupId { get; set; }
        public Guid StudentId { get; set; }
        public bool Active { get; set; }
        //{
        //    get => _itemsPerPage = _itemsPerPage == 0 ? _maxItemsPerPage : _itemsPerPage;
        //    set => _itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value;
        //}
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGroupMemberDto, UpdateGroupMemberCommand>()
                .ForMember(entityDto => entityDto.GroupMemberId,
                    opt => opt.MapFrom(entity => entity.GroupMemberId))
                .ForMember(entityDto => entityDto.GroupId,
                    opt => opt.MapFrom(entity => entity.GroupId))
                .ForMember(entityDto => entityDto.StudentId,
                    opt => opt.MapFrom(entity => entity.StudentId))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }
    }
}
