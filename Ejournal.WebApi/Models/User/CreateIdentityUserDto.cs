using AutoMapper;
using Ejournal.Application.Application.Command.User_s.CreateUser;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.User
{
    public class CreateIdentityUserDto : IMapWith<CreateAspNetUserCommand>
    {
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateIdentityUserDto, CreateAspNetUserCommand>()
                .ForMember(entityDto => entityDto.Email,
                    opt => opt.MapFrom(entity => entity.Email))
                .ForMember(entityDto => entityDto.PhoneNumber,
                    opt => opt.MapFrom(entity => entity.PhoneNumber))
                .ForMember(entityDto => entityDto.Password,
                    opt => opt.MapFrom(entity => entity.Password));
        }
    }
}
