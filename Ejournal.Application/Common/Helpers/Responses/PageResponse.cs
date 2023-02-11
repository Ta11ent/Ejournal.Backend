using Ejournal.Application.Common.Helpers.Filters;
using Ejournal.Application.Interfaces;
using System.Collections;

namespace Ejournal.Application.Common.Helpers.Responses
{
    public class PageResponse<T> : IResponse<T> where T : IList
    {
        public PageResponse() { }
        public PageResponse(T data, IPaginationParams parametrs, int count)
        {
            Data = data;
            Succeeded = true;
            Page = parametrs.Page;
            PageSize = parametrs.PageSize;
            Records = data.Count;
            TotalRecords = count;
           
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Records { get; set; }
        public int TotalRecords { get; set; }
    }
}
