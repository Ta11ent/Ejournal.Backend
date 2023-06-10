namespace Enews.WebApi.Models
{
    public class UpdateNewsFileDto
    {
        public IFormFile File { get; set; }

        public static async ValueTask<UpdateNewsFileDto?> BindAsync(HttpContext context, ParameterInfo parameter)
        {
            var form = await context.Request.ReadFormAsync();
            var file = form.Files["File"];
            return new UpdateNewsFileDto
            {
                File = file
            };
        }
    }
}
