using Ejournal.Application.Interfaces;

namespace Ejournal.Application.Common.Helpers.Filters
{
    public class FilterParams : IPaginationParams, IFilterContextParams
    {
        private const int _maxItemsPerPage = 20;
        private int _itemsPerPage;
        public int Page { get; set; } = 1;
        public int PageSize
        {
            get => _itemsPerPage = _itemsPerPage == 0 ? _maxItemsPerPage : _itemsPerPage;
            set => _itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value;
        }
        private bool? _active = true;
        public bool? Active
        {
            get => _active;
            set => _active = value ?? true;
        }
    }
}
