using Microsoft.AspNetCore.Http;

namespace Enews.Application.Models
{
    public class CreateNews
    {
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public IFormFile? File { get; set; }   
        public string Path { get; set; }
    }
}
