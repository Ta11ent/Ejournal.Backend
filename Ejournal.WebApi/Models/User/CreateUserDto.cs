using AutoMapper;
using Ejournal.Application.Application.Command.User_s.CreateUser;
using Ejournal.Application.Common.Mappings;

namespace Ejournal.WebApi.Models.User
{
    public class CreateUserDto : IMapWith<CreateUserCommand>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public bool CreateIdentity { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateUserDto, CreateUserCommand>()
                .ForMember(entityDto => entityDto.FirstName,
                    opt => opt.MapFrom(entity => entity.FirstName))
                .ForMember(entityDto => entityDto.MiddleName,
                    opt => opt.MapFrom(entity => entity.MiddleName))
                .ForMember(entityDto => entityDto.LastName,
                    opt => opt.MapFrom(entity => entity.LastName))
                .ForMember(entityDto => entityDto.Gender,
                    opt => opt.MapFrom(entity => entity.Gender));
        }
    }
}
