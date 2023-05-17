namespace Enews.WebApi.Models.News
{
    public class UpdateNewsDto : IMapWith<UpdateNews>
    {
        public Guid NewsId { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public Guid FileId { get; set; }
        public string FilePath { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNewsDto, UpdateNews>()
                .ForMember(dto => dto.NewsId,
                    opt => opt.MapFrom(entity => entity.NewsId))
                .ForMember(dto => dto.HeadTitle,
                    opt => opt.MapFrom(entity => entity.HeadLine))
                .ForMember(dto => dto.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(dto => dto.FileId,
                    opt => opt.MapFrom(entity => entity.FileId))
                .ForMember(dto => dto.FilePath,
                    opt => opt.MapFrom(entity => entity.FilePath));
        }
    }
}
