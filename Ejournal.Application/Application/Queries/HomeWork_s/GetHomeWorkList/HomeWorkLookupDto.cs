using AutoMapper;
using Ejournal.Application.Common.Mappings;
using Ejournal.Domain;
using System;

namespace Ejournal.Application.Application.Queries.HomeWork_s.GetHomeWorkList
{
    public class HomeWorkLookupDto : IMapWith<HomeWork>
    {
        public Guid HomeWorkId { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Group { get; set; }
        public string Subject { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<HomeWork, HomeWorkLookupDto>()
                .ForMember(entityDto => entityDto.HomeWorkId,
                    opt => opt.MapFrom(entity => entity.HomeWorkId))
                 .ForMember(entityDto => entityDto.Date,
                    opt => opt.MapFrom(entity => entity.Date))
                  .ForMember(entityDto => entityDto.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                   .ForMember(entityDto => entityDto.Group,
                    opt => opt.MapFrom(entity => entity.StudentGroup.Name))
                    .ForMember(entityDto => entityDto.Subject,
                    opt => opt.MapFrom(entity => entity.Subject.Name));
        }
    }
}
