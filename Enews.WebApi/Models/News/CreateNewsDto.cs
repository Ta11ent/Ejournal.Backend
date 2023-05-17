namespace Enews.WebApi.Models.News
{
    public class CreateNewsDto : IMapWith<CreateNews>
    {
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewsDto, CreateNews>()
                .ForMember(dto => dto.HeadLine,
                    opt => opt.MapFrom(entity => entity.HeadLine))
                .ForMember(dto => dto.Description,
                    opt => opt.MapFrom(entity => entity.Description));
        }
    }
}