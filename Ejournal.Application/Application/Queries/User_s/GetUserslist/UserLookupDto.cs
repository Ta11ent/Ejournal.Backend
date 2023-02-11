using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.User_s.GetUserslist
{
    public class UserLookupDto : IMapWith<User>
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public bool HasAccount { get; set; }
        public bool Active { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>()
                .ForMember(entityDto => entityDto.UserId,
                    opt => opt.MapFrom(entity => entity.UserId))
                .ForMember(entityDto => entityDto.FirstName,
                    opt => opt.MapFrom(entity => entity.FirstName))
                .ForMember(entityDto => entityDto.MiddleName,
                    opt => opt.MapFrom(entity => entity.MiddleName))
                .ForMember(entityDto => entityDto.LastName,
                    opt => opt.MapFrom(entity => entity.LastName))
                .ForMember(entityDto => entityDto.Birthday,
                    opt => opt.MapFrom(entity => entity.Birthday))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.Active));
        }

    }
}
