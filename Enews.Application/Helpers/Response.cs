using Enews.Application.Interfaces;

namespace Enews.Application.Helpers
{
    public class Response<T> : IResponse<T> where T : class
    {   
        public Response(T data) {
            Data = data;
            Success = true;
        }
        public T Data { get; }
        public bool Success { get; }
    }
}
