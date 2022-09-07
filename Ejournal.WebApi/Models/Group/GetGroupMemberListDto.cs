using AutoMapper;
using Ejournal.Application.Application.Queries.GroupMember_s.GetGroupMemberList;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;

namespace Ejournal.WebApi.Models.Group
{
    public class GetGroupMemberListDto : IMapWith<GetGroupMemberListQuery>, IPaginationParams
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public bool? Active { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<GetGroupMemberListDto, GetGroupMemberListQuery>()
                .ForPath(entityDto => entityDto.Parametrs.Page,
                    opt => opt.MapFrom(entity => entity.Page))
                .ForPath(entityDto => entityDto.Parametrs.PageSize,
                    opt => opt.MapFrom(entity => entity.PageSize))
                .ForPath(entityDto => entityDto.Parametrs.Active,
                    opt => opt.MapFrom(entity => entity.Active));

        }
    }
}
