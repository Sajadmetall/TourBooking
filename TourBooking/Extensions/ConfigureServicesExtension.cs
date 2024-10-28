using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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
            //services.AddApiVersioning(x =>
            //{
            //    x.DefaultApiVersion = new ApiVersion(1, 0);
            //    x.AssumeDefaultVersionWhenUnspecified = true;
            //    x.ReportApiVersions = true;
            //});
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
            services.AddSwaggerGen();

            //services.AddSwaggerGen(setup =>
            //{
            //    // Include 'SecurityScheme' to use JWT Authentication
            //    var jwtSecurityScheme = new OpenApiSecurityScheme
            //    {
            //        BearerFormat = "JWT",
            //        Name = "JWT Authentication",
            //        In = ParameterLocation.Header,
            //        Type = SecuritySchemeType.Http,
            //        Scheme = JwtBearerDefaults.AuthenticationScheme,
            //        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

            //        Reference = new OpenApiReference
            //        {
            //            Id = JwtBearerDefaults.AuthenticationScheme,
            //            Type = ReferenceType.SecurityScheme
            //        }
            //    };

            //    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            //    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
            //    {
            //        { jwtSecurityScheme, Array.Empty<string>() }
            //    });
            //});

            var secretKey = configuration.GetValue<string>("SecretKey");
            //services.AddAuthentication(options =>
            //{
            //    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //    options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            //}).AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            //    {
            //        ValidateIssuerSigningKey = true,
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey ?? string.Empty)),
            //        ValidateLifetime = true,
            //        ValidateIssuer = false,
            //        ValidateAudience = false,
            //        ClockSkew = TimeSpan.Zero
            //    };
            //});

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
