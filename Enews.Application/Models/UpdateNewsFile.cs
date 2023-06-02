using Microsoft.AspNetCore.Http;

namespace Enews.Application.Models
{
    public class UpdateNewsFile
    {
        public Guid NewsId { get; set; }
        public Guid FileId { get; set; }
        public IFormFile File { get; set; }
        public string Path { get; set; }
    }
}
