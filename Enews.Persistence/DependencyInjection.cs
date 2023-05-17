using Enews.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Enews.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddEnewsData(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<NewsDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<INewsDbContext>(provide => provide.GetService<NewsDbContext>());
            //services.AddScoped<INewsDbContext, NewsDbContext>();
            
            return services;
        } 
    }
}
