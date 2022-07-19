using Ejournal.Persistence;
using Ejournal.Person;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejournal.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;

                //Sourse Db initialization
                try 
                {
                    var context = serviceProvider.GetRequiredService<EjournalDbContext>();
                    Persistence.DbInitializer.Initialize(context);
                }
                catch (Exception exception)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "Ann error ocurred while app initialization");
                }

                //Identity Db Initialization
                try 
                {
                    var context = serviceProvider.GetRequiredService<PersonDbContext>();
                    Person.DbInitializer.Initialize(context);
                }
                catch(Exception exception)
                {
                    var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(exception, "Ann error ocurred while app initialization");

                }

            }                
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
