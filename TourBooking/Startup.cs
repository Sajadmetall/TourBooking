
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using TourBooking.Application.Services;
using TourBooking.Infrastructure.DBContext;
using TourBooking.Infrastructure.Repositories;

namespace TourBooking
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddDbContext<ApplicationDBContext>(
                options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));


            services.AddScoped(typeof(IBookingRepository), typeof(BookingRepository));

            services.AddScoped(typeof(IPartyLeaderRepository), typeof(PartyLeaderRepository));
            services.AddScoped(typeof(IBookingService), typeof(BookingService));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TourBooking", Version = "v1" });
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDBContext dataContext)
        {
            dataContext.Database.Migrate();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TourBooking v1"));
            }

            app.UseExceptionHandler("/error");
            app.UseHttpsRedirection();


            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
