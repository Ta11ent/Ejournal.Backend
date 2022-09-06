using Ejournal.Application;
using Ejournal.Application.Common.Mappings;
using Ejournal.Application.Interfaces;
using Ejournal.Persistence;
using Ejournal.Person;
using Ejournal.WebApi.Middleware;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using Ejournal.WebApi.Helpers;
using System.IO;
using System;

namespace Ejournal.WebApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IEjournalDbContext).Assembly));
                config.AddProfile(new AssemblyMappingProfile(typeof(IPersonDbContext).Assembly));
            });

            services.AddAplication();
            services.AddPersistence(Configuration);
            services.AddPerson(Configuration);
            services.AddControllers();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            services.AddAuthentication(config =>
            {
                config.DefaultAuthenticateScheme =
                    JwtBearerDefaults.AuthenticationScheme;
                config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer("Bearer", options =>
                {
                    options.Authority = "https://localhost:44384/";
                    options.Audience = "ejournal_web_api";
                    options.RequireHttpsMetadata = false;
                });

            services.AddAuthorization(config =>
           {
               config.AddPolicy(Policy.Admin, policy =>
               {
                   policy.RequireClaim(ClaimLevel.Type, ClaimLevel.High);
                   policy.RequireClaim(ClaimLevel.Type, ClaimLevel.Medium);
                   policy.RequireClaim(ClaimLevel.Type, ClaimLevel.Low);
               });
               config.AddPolicy(Policy.Management, policy =>
               {
                   policy.RequireClaim(ClaimLevel.Type, ClaimLevel.High);
                   policy.RequireClaim(ClaimLevel.Type, ClaimLevel.Medium);
               });
               config.AddPolicy(Policy.Professor, policy =>
               {
                   policy.RequireClaim(ClaimLevel.Type, ClaimLevel.Medium);
                   policy.RequireClaim(ClaimLevel.Type, ClaimLevel.Low);
               });
               config.AddPolicy(Policy.Student, policy =>
               {
                   policy.RequireClaim(ClaimLevel.Type, ClaimLevel.Low);
               });
           });

            services.AddSwaggerGen(config =>
            {
                config.CustomSchemaIds(type => type.ToString());
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments(xmlPath);
            });
            services.AddApiVersioning();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(config => 
            {
                config.RoutePrefix = string.Empty;
                config.SwaggerEndpoint("swagger/v1/swagger.json", "Ejournal API");
            });
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseApiVersioning();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
