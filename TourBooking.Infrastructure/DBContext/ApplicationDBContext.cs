using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TourBooking.Domain.Entities;

namespace TourBooking.Infrastructure.DBContext
{
    public class ApplicationDBContext : DbContext
    {


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingPartyLeader> BookingPartyLeaders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }

    }

}
