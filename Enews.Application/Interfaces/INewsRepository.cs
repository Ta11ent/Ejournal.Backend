using Enews.Application.Models;
public interface INewsRepository : IDisposable
{
    Task<IEnumerable<NewsLookup>> GetNewsListAsync();
    Task<NewsDetails> GetNewsAsync(Guid Id);
    Task CreateNewsAsync(CreateNews model);
    Task UpdateNewsAsync(UpdateNews model);
    Task DeleteAsync(Guid Id);
    Task SaveAsync();

}
