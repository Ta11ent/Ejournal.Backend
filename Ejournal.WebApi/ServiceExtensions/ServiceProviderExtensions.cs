using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Ejournal.WebApi.ServiceExtensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddConfigureSwaggerExtensions(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        }
    }
}