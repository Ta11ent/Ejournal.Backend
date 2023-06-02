using Enews.Application.Models;
public interface INewsRepository : IDisposable
{
    Task<List<NewsLookup>> GetNewsListAsync(GetNewsLookup data);
    Task<NewsDetails> GetNewsAsync(Guid Id);
    Task<Guid> CreateNewsAsync(CreateNews model);
    Task<bool> UpdateNewsAsync(UpdateNews model);
    Task<bool> UpdateNewsFileAsync(UpdateNewsFile model);
    Task<bool> DeleteAsync(Guid Id);
    Task SaveAsync();

}
