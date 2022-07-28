using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.User_s.GetUserDetails
{
    public class UserDetailsVm : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            //profile.CreateMap<User, UserDetailsVm>()
            //    .ForMember(entityVm => entityVm.Id,
            //        opt => opt.MapFrom(entity => entity.Id))
            //    .ForMember(entityVm => entityVm.FirstName,
            //        opt => opt.MapFrom(entity => entity.FirstName))
            //    .ForMember(entityVm => entityVm.MiddleName,
            //        opt => opt.MapFrom(entity => entity.MiddleName))
            //    .ForMember(entityVm => entityVm.LastName,
            //        opt => opt.MapFrom(entity => entity.LastName))
            //    .ForMember(entityVm => entityVm.PhoneNumber,
            //        opt => opt.MapFrom(entity => entity.PhoneNumber))
            //      .ForMember(entityVm => entityVm.Email,
            //        opt => opt.MapFrom(entity => entity.Email));
        }
    }
}
