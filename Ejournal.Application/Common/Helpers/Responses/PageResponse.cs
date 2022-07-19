﻿using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Interfaces;
using System.Collections;

namespace Ejournal.Application.Common.Helpers.Responses
{
    public class PageResponse<T> : IResponse<T> where T : IList
    {
        public PageResponse() { }
        public PageResponse(T data, PaginationParams parametrs)
        {
            Data = data;
            Succeeded = true;
            Page = parametrs.Page;
            PageSize = parametrs.PageSize;
            Records = data.Count;
           
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Records { get; set; }
    }
}
