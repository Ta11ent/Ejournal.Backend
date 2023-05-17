namespace Enews.Domain
{
    public class NewsFile
    {
        public Guid FileId { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public Guid NewsId { get; set; }
        public News News { get; set; }

    }
}
