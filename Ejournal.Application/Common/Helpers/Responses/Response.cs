using Ejournal.Application.Interfaces;

namespace Ejournal.Application.Common.Helpers.Responses
{
    public class Response<T> : IResponse<T> where T : class
    {
        public Response() { }

        public Response(T data)
        {
            Succeeded = true;
            Data = data;
        }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
    }
}
