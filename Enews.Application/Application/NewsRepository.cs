using AutoMapper;
using AutoMapper.QueryableExtensions;
using Enews.Application.Interfaces;
using Enews.Application.Models;
using Enews.Domain;
using Microsoft.EntityFrameworkCore;

namespace Enews.Application.Application
{
    public class NewsRepository : INewsRepository
    {
        private readonly INewsDbContext _dbContext;
        private readonly IFileHandler _fileHandler;
        private readonly IMapper _mapper;
        private bool _disposed = false;
        public NewsRepository(INewsDbContext dbContext, IFileHandler fileHandler, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _fileHandler = fileHandler;
            _mapper = mapper; 
        }
           
        public async Task<Guid> CreateNewsAsync(CreateNews model)
        {
            var news = new News
            {
                NewsId = Guid.NewGuid(),
                HeadLine = model.HeadLine,
                Description = model.Description,
                DateCreation = DateTime.Now
            };
            await _dbContext.News.AddAsync(news);


            if (model.File is not null)
            {
                await _fileHandler.CopyFileToFolder(model.File, model.Path);
                var file = new NewsFile
                {
                    FileId = Guid.NewGuid(),
                    NewsId = news.NewsId,
                    Name = model.File.FileName,
                    Path = model.Path + @"\" + model.File.FileName
                };
                await _dbContext.NewsFiles.AddAsync(file);
            }

            return news.NewsId;
        }
        public async Task<NewsDetails> GetNewsAsync(Guid Id)
        {
           var entity = 
                await _dbContext.News
                .Include(e => e.File)
                .Where(e => e.NewsId == Id)
                .ProjectTo<NewsDetails>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return entity!;
        }

        public async Task<List<NewsLookup>> GetNewsListAsync(GetNewsLookup data)
        {
            var entity =
                 await _dbContext.News
                 .Include(e => e.File)
                 .Skip((data.Page - 1) * data.PageSize)
                 .Take(data.PageSize)
                 .ProjectTo<NewsLookup>(_mapper.ConfigurationProvider)
                 .ToListAsync();

            return entity;
        }
        public async Task<bool> UpdateNewsAsync(UpdateNews model)
        {
            var entity = await _dbContext.News.FindAsync(new object[] { model.NewsId});
            if(entity is null) 
                return false;

            entity.HeadLine = model.HeadTitle;
            entity.Description = model.Description;
            return true;
        }

        public async Task<bool> UpdateNewsFileAsync(UpdateNewsFile model)
        {
            var entity = 
                await _dbContext.NewsFiles
                .FirstOrDefaultAsync(e => 
                    e.NewsId == model.NewsId &&
                    e.FileId == model.FileId);
            if (entity is null)
                return false;

            _fileHandler.DeleteFileFromFolder(entity.Path);

            await _fileHandler.CopyFileToFolder(model.File, model.Path);
            entity.Name = model.File.FileName;
            entity.Path = model.Path + @"\" + model.File.FileName;

            return true;
        }
        public async Task<bool> DeleteAsync(Guid Id)
        {
            var news = 
                await _dbContext.News
                .Include(e => e.File)
                .FirstOrDefaultAsync(e => e.NewsId == Id);

            if (news is null)
                return false;

            _fileHandler.DeleteFileFromFolder(news.File.Path);

            _dbContext.News.Remove(news);
            return true;
        }

        public async Task SaveAsync() => await _dbContext.SaveChangesAsync();
      
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if(disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }
    }
}
