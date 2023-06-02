using AutoMapper;
using Enews.Application.Mapping;
using Enews.Domain;

namespace Enews.Application.Models
{
    public class NewsDetails : IMapWith<News>
    {
        public Guid NewsId { get; set; }
        public string HeadLime { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime DateCreation { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<News, NewsDetails>()
                .ForMember(vm => vm.NewsId,
                    opt => opt.MapFrom(entity => entity.NewsId))
                .ForMember(vm => vm.HeadLime,
                   opt => opt.MapFrom(entity => entity.HeadLine))
                .ForMember(vm => vm.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(vm => vm.FileId,
                    opt => opt.MapFrom(entity => entity.File.FileId))
                .ForMember(vm => vm.FileName,
                    opt => opt.MapFrom(entity => entity.File.Name))
                .ForMember(vm => vm.FilePath,
                    opt => opt.MapFrom(entity => entity.File.Path))
                .ForMember(vm => vm.DateCreation,
                    opt => opt.MapFrom(entity => entity.DateCreation));
        }
    }
}
