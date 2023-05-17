namespace Enews.Application.Models
{
    public class UpdateNews
    {
        public Guid NewsId { get; set; }
        public string HeadTitle {get;set;}
        public string Description { get; set; }
        public Guid FileId { get; set; }
        public string FilePath { get; set; }
    }
}
