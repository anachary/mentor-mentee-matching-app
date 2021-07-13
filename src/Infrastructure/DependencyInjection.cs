using IdentityServer4.Models;
using MentorMenteeApp.Application.Common.Interfaces;
using MentorMenteeApp.Domain.Entities;
using MentorMenteeApp.Infrastructure.Identity;
using MentorMenteeApp.Infrastructure.Persistence;
using MentorMenteeApp.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MentorMenteeApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                     configuration.GetConnectionString("DefaultConnection"),
                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
            }

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());


            services
                .AddDefaultIdentity<User>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentityServer()
                .AddInMemoryClients(new Client[]
                {
                    new Client
                    {
                        ClientId ="mentor-mentee-app-frontend",
                        AllowedGrantTypes = GrantTypes.Code,
                        RedirectUris = new []{"http://localhost:3000"},
                        PostLogoutRedirectUris= new []{"https://localhost:3000"},
                        AllowedCorsOrigins = new []{"http://localhost:3000"} ,
                        RequireConsent = false,
                        AllowAccessTokensViaBrowser= true,
                        RequirePkce= true,
                        RequireClientSecret= false
                    }
                })
                .AddApiAuthorization<User, ApplicationDbContext>();

            services.AddTransient<IDateTime, DateTimeService>();
            services.AddTransient<IIdentityService, IdentityService>();

            services.AddAuthentication()
                .AddIdentityServerJwt();



            services.AddAuthorization(options =>
            {
                options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator"));
            });

            return services;
        }
    }
}