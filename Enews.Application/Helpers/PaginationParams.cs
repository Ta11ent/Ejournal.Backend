using Enews.Application.Interfaces;
namespace Enews.Application.Helpers
{
    public class PaginationParams : IPaginationParams
    {
        private readonly int maxPageSize = 20;
        private readonly int minPage = 1;
        private int pageSize;
        private int page;
        public int Page
        {
            get => page;
            set => page = value == 0 ? minPage : value;
        }
        public int PageSize
        {
            get => pageSize = pageSize <= 0 ? maxPageSize : pageSize;
            set => pageSize = value > maxPageSize ? maxPageSize : value;
        }
    }
}
