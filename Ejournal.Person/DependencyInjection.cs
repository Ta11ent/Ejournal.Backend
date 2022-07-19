using Ejournal.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Ejournal.Person
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPerson(this IServiceCollection
            services, IConfiguration configuration)
        {
            var connectionString = configuration["DbIdentityConnection"];
            services.AddDbContext<PersonDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });
            services.AddScoped<IPersonDbContext>(provide => provide.GetService<PersonDbContext>());

            return services;
        }
    }
}
