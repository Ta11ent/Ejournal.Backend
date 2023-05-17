namespace Enews.Application.Models
{
    public class NewsDetails
    {
        public Guid NewsId { get; set; }
        public string HeadLime { get; set; }
        public string Description { get; set; }
        public string FileId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
