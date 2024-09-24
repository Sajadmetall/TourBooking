using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Application.Services;
using TourBooking.Domain.Contracts;
using TourBooking.Infrastructure.DBContext;
using TourBooking.Infrastructure.Repositories;

namespace TourBooking.Extensions
{
    public static class ConfigureServicesExtension
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddControllers();
            services.AddApiVersioning(x =>
            {
                x.DefaultApiVersion = new ApiVersion(1, 0);
                x.AssumeDefaultVersionWhenUnspecified = true;
                x.ReportApiVersions = true;
            });
            services.AddDbContext<ApplicationDBContext>(
                options => {
                    options.UseSqlServer("name=ConnectionStrings:DefaultConnection");
                    options.EnableSensitiveDataLogging();
                });


            services.AddScoped(typeof(IBookingRepository), typeof(BookingRepository));

            services.AddScoped(typeof(IPartyLeaderRepository), typeof(PartyLeaderRepository));
            services.AddScoped(typeof(IBookingService), typeof(BookingService));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TourBooking", Version = "v1" });
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = Configuration["Jwt:Issuer"],
            ValidAudience = Configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
        };
    });
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder =>
                       builder.WithOrigins("http://localhost:4200")
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                .Build());
            });

        }
    }
}
