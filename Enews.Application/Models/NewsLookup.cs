using AutoMapper;
using Enews.Application.Mapping;
using Enews.Domain;

namespace Enews.Application.Models
{
    public class NewsLookup : IMapWith<News>
    {
        public Guid NewsId { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public DateTime DateCreation {get;set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<News, NewsLookup>()
                .ForMember(vm => vm.NewsId,
                    opt => opt.MapFrom(entity => entity.NewsId))
                .ForMember(vm => vm.HeadLine,
                    opt => opt.MapFrom(entity => entity.HeadLine))
                .ForMember(vm => vm.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(vm => vm.Path,
                    opt => opt.MapFrom(entity => entity.File.Path))
                .ForMember(vm => vm.DateCreation,
                    opt => opt.MapFrom(entity => entity.DateCreation));
        }
    }
}
