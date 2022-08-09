using AutoMapper;
using Ejournal.Application.Application.Command.User_s.CreateUser;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.User
{
    public class CreateIdentityUserDto : IMapWith<CreateAspNetUserCommand>
    {
        public Guid Id { get; set; }
        public bool CreateIdentity { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateIdentityUserDto, CreateAspNetUserCommand>()
                .ForMember(entityDto => entityDto.Id,
                    opt => opt.MapFrom(entity => entity.Id))
                .ForMember(entityDto => entityDto.UserName,
                    opt => opt.MapFrom(entity => entity.UserName))
                .ForMember(entityDto => entityDto.Email,
                    opt => opt.MapFrom(entity => entity.Email))
                .ForMember(entityDto => entityDto.PhoneNumber,
                    opt => opt.MapFrom(entity => entity.PhoneNumber));
        }
    }
}
