namespace Enews.Application.Models
{
    public class NewsLookup
    {
        public Guid NewsId { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public string Path { get; set; }
        public DateTime DateCreation {get;set; }
    }
}
