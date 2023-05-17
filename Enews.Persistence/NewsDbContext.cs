using Enews.Application.Interfaces;
using Enews.Domain;
using Enews.Persistence.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Enews.Persistence
{
    public class NewsDbContext : DbContext, INewsDbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<NewsFile> NewsFiles { get; set; }

        public NewsDbContext(DbContextOptions<NewsDbContext> options)
           : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new NewsFileConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
