using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;

namespace Ejournal.Application.Application.Queries.User_s.GetUserslist
{
    public class UserLookupDto : IMapWith<AspNetUser>
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName {get;set;}

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AspNetUser, UserLookupDto>()
                .ForMember(entityDto => entityDto.Id,
                    opt => opt.MapFrom(entity => entity.Id))
                .ForMember(entityDto => entityDto.FirstName,
                    opt => opt.MapFrom(entity => entity.FirstName))
                .ForMember(entityDto => entityDto.MiddleName,
                    opt => opt.MapFrom(entity => entity.MiddleName))
                .ForMember(entityDto => entityDto.LastName,
                    opt => opt.MapFrom(entity => entity.LastName));
        }

    }
}
