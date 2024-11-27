using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Graph.ExternalConnectors;
using Microsoft.Identity.Client;
using Microsoft.Identity.Web;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using TourBooking.Application.Services;
using TourBooking.Domain.Contracts;
using TourBooking.Infrastructure.DBContext;
using TourBooking.Infrastructure.Repositories;

namespace TourBooking.Extensions
{
    public static class ConfigureServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddControllers();
            services.AddDbContext<ApplicationDBContext>(
                options =>
                {
                    options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
                    options.EnableSensitiveDataLogging();
                });


            services.AddScoped(typeof(IBookingRepository), typeof(BookingRepository));

            services.AddScoped(typeof(IPartyLeaderRepository), typeof(PartyLeaderRepository));
            services.AddScoped(typeof(IBookingService), typeof(BookingService));
            // Add Swagger services
            services.AddEndpointsApiExplorer();
            

            //var secretKey = configuration.GetValue<string>("SecretKey");
            services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
            .AddMicrosoftIdentityWebApp(configuration.GetSection("AzureAd"));
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.OAuth2,
                    Flows = new OpenApiOAuthFlows
                    {
                        Implicit = new OpenApiOAuthFlow
                        {
                            AuthorizationUrl = new Uri("https://login.microsoftonline.com/7c49e7f3-6eea-4329-9411-c56a19dcbb35/oauth2/v2.0/authorize"),
                            Scopes = new Dictionary<string, string>
                            {
                                { "api://d8319494-9692-47d6-a7fb-3c23ebf26ece/access_as_user", "Access API" }
                            }
                        }
                    },
                    Description = "Microsoft Entra ID OAuth2 Implicit Flow"
                });

                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "oidc"
                            }
                        },
                        new[] { "openid", "profile", "email" }
                    }
                });
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(policy =>
                {
                    policy.WithOrigins("https://localhost:49155/", "https://localhost:5001/") // Or restrict to specific origins with .WithOrigins("http://example.com")
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
        }
    }
}
