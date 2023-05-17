using Enews.Application.Interfaces;
using Enews.Application.Models;
using Enews.Domain;

namespace Enews.Application.Application
{
    public class NewsRepository : INewsRepository
    {
        private readonly INewsDbContext _dbContext;
        public NewsRepository(INewsDbContext dbContext) =>
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));

        public async Task CreateNewsAsync(CreateNews model)
        {
            var news = new News
            {
                NewsId = new Guid(),
                HeadLine = model.HeadLine,
                Description = model.Description,
                DateCreation = DateTime.Now
            };
            await _dbContext.News.AddAsync(news);
        }

        public Task DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<NewsDetails> GetNewsAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<NewsLookup>> GetNewsListAsync()
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();

        public Task UpdateNewsAsync(UpdateNews model)
        {
            throw new NotImplementedException();
        }
    }
}
