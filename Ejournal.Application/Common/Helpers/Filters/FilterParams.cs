using Ejournal.Application.Interfaces;
using System;

namespace Ejournal.Application.Common.Helpers.Filters
{
    public class FilterParams : IPaginationParams, IFilterContextParams
    {
        private const int _maxItemsPerPage = 20;
        private int _itemsPerPage;
        private const int _startPage = 1;
        private int _numberOfPage;
        public int Page
        {
            get => _numberOfPage;
            set => _numberOfPage = value == 0 ? _startPage : value; 
        }
        public int PageSize
        {
            get => _itemsPerPage = _itemsPerPage == 0 ? _maxItemsPerPage : _itemsPerPage;
            set => _itemsPerPage = value > _maxItemsPerPage ? _maxItemsPerPage : value;
        }
        public bool? Active { get; set; } 
        public DateTime? DateFrom { get; set; } 
        public DateTime? DateTo { get; set; }
        public Guid? Group { get; set; }
        public Guid? ClassMember { get; set; }
        public Guid? Membership { get; set; }
        public Guid? Subject { get; set; }
    }
}
