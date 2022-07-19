using Ejournal.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ejournal.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<EjournalDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IEjournalDbContext>(provide => provide.GetService<EjournalDbContext>());

            return services;
        }
    }
}