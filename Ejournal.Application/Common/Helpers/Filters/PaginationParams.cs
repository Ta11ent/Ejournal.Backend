namespace Ejournal.Application.Common.Helpers.Filters
{
    public class PaginationParams
    {
        private const int _maxItemsPerPage = 20;
        private int _itemsPerPage;
        public int Page { get; set; } = 1;
        public int PageSize
        {
            get => _itemsPerPage = _itemsPerPage == 0 ? _maxItemsPerPage : _itemsPerPage;
            set => _itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage: value;
        }
    }
}