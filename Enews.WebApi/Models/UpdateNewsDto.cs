namespace Enews.WebApi.Models
{
    public class UpdateNewsDto : IMapWith<UpdateNews>
    {
        public string HeadLine { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNewsDto, UpdateNews>()
                .ForMember(dto => dto.HeadTitle,
                    opt => opt.MapFrom(entity => entity.HeadLine))
                .ForMember(dto => dto.Description,
                    opt => opt.MapFrom(entity => entity.Description));
        }

        public static async ValueTask<UpdateNewsDto?> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            var headLine = form["HeadLine"];
            var description = form["Description"];
            return new UpdateNewsDto
            {
                HeadLine = headLine,
                Description = description,
            };
        }
    }
}
