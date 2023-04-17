using AuthenticationManager.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;


namespace AuthenticationManager
{
    public static class AuthenticationManager
    {
        public static IServiceCollection AddAuthenticationManager(this IServiceCollection services)
        {
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
            return services;
        }
    }
}
