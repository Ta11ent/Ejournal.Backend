namespace Ejournal.Application.Interfaces
{
    public interface IPaginationParams
    {
        int Page { get; set; }
        int PageSize { get; set; }
    }
}
