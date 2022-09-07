using AutoMapper;
using Ejournal.Application.Application.Command.User_s.UpdateUser;
using Ejournal.Application.Common.Mappings;
using System;

namespace Ejournal.WebApi.Models.User
{
    public class UpdateUserDto : IMapWith<UpdateUserCommand>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public bool UserActive { get; set; }
        public bool? AccountActive { get; set; }
        public bool HasAccount { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateUserDto, UpdateUserCommand>()
                .ForMember(entityDto => entityDto.FirstName,
                    opt => opt.MapFrom(entity => entity.FirstName))
                .ForMember(entityDto => entityDto.MiddleName,
                    opt => opt.MapFrom(entity => entity.MiddleName))
                .ForMember(entityDto => entityDto.LastName,
                    opt => opt.MapFrom(entity => entity.LastName))
                .ForMember(entityDto => entityDto.Gender,
                    opt => opt.MapFrom(entity => entity.Gender))
                .ForMember(entityDto => entityDto.Birthday,
                    opt => opt.MapFrom(entity => entity.Birthday))
                .ForMember(entityDto => entityDto.Active,
                    opt => opt.MapFrom(entity => entity.UserActive))
                .ForMember(entityDto => entityDto.HasAccount,
                    opt => opt.MapFrom(entity => entity.HasAccount));
        }
    }
}
