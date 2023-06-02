using Enews.Application.Interfaces;
using System.Collections;

namespace Enews.Application.Helpers
{
    public class PageResponse<T> : IResponse<T> where T : IList
    {
        public PageResponse(T data, IPaginationParams param) { 
            Data = data;
            Success = true;
            Page = param.Page;
            PageSize = param.PageSize;
            Records = data.Count;
        }
        public T Data { get; }
        public bool Success { get; }
        public int Page { get; }
        public int PageSize { get; }
        public int Records { get; }
    }
}
