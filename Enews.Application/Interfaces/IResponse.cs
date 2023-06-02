namespace Enews.Application.Interfaces
{
    internal interface IResponse<T>
    {
        T Data { get; }
        bool Success { get; }
    }
}
