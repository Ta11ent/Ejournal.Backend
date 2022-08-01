﻿using Ejournal.Application.Interfaces;
using System;

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

        private DateTime _dateFrom = new DateTime(2000, 1, 1);
        private DateTime _dateTo = new DateTime(2099, 12, 31);
        public DateTime? DateFrom
        {
            get => _dateFrom;
            set => _dateFrom = value ?? _dateFrom;
        }
        public DateTime? DateTo
        {
            get => _dateTo;
            set => _dateTo = value ?? _dateTo;
        }
        public Guid? Student { get; set; }
        public Guid? Professor { get; set; }
    }
}