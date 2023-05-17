namespace Enews.Application.Interfaces
{
    public interface IRepository<T>
    {
        Task CreateAsync(T model);
    }
}
