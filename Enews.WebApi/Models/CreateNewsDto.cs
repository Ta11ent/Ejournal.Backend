namespace Enews.WebApi.Models
{
    public class CreateNewsDto : IMapWith<CreateNews>
    {
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public IFormFile? File { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewsDto, CreateNews>()
                .ForMember(dto => dto.HeadLine,
                    opt => opt.MapFrom(entity => entity.HeadLine))
                .ForMember(dto => dto.Description,
                    opt => opt.MapFrom(entity => entity.Description))
                .ForMember(dto => dto.File,
                    opt => opt.MapFrom(entity => entity.File));
        }

        public static async ValueTask<CreateNewsDto?> BindAsync(HttpContext context)
        {
            var form = await context.Request.ReadFormAsync();
            var file = form.Files["File"];
            var headLine = form["HeadLine"];
            var description = form["Description"];
            return new CreateNewsDto
            {
                HeadLine = headLine,
                Description = description,
                File = file
            };
        }
    }
}