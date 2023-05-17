namespace Enews.Domain
{
    public class News
    {
        public Guid NewsId { get; set; }
        public string HeadLine { get; set; }
        public string Description { get; set; }
        public DateTime DateCreation { get; set; }
        public NewsFile? FileId { get; set; }
    }
}
