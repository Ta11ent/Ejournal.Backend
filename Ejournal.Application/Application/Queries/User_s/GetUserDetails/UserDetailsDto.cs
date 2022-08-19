using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.User_s.GetUserDetails
{
    public class UserDetailsDto : IMapWith<User>
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public bool Gender { get; set; }
        public DateTime Birthday { get; set; }
        public bool Active { get; set;  }
        public bool HasAccount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsDto>()
                .ForMember(entityVm => entityVm.UserId,
                    opt => opt.MapFrom(entity => entity.UserId))
                .ForMember(entityVm => entityVm.FirstName,
                    opt => opt.MapFrom(entity => entity.FirstName))
                .ForMember(entityVm => entityVm.MiddleName,
                    opt => opt.MapFrom(entity => entity.MiddleName))
                .ForMember(entityVm => entityVm.LastName,
                    opt => opt.MapFrom(entity => entity.LastName))
                .ForMember(entityVm => entityVm.Gender,
                    opt => opt.MapFrom(entity => entity.Gender))
                .ForMember(entityVm => entityVm.Birthday,
                    opt => opt.MapFrom(entity => entity.Birthday))
                .ForMember(entityVm => entityVm.Active,
                    opt => opt.MapFrom(entity => entity.Active))
                .ForMember(entityVm => entityVm.HasAccount,
                    opt => opt.MapFrom(entity => entity.HasAccount));
        }
    }
}
