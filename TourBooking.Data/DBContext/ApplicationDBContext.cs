using TourBooking.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBooking.Data.DBContext
{
    public class ApplicationDBContext : DbContext
    {


        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingPartyLeader> BookingPartyLeaders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BookingPartyLeader>().HasKey(sc => new { sc.BookingId, sc.PartyLeaderId });

            modelBuilder.Entity<BookingPartyLeader>()
                .HasOne<Booking>(sc => sc.Booking)
                .WithMany(s => s.BookingPartyLeaders)
                .HasForeignKey(sc => sc.BookingId);


            modelBuilder.Entity<BookingPartyLeader>()
                .HasOne<PartyLeader>(sc => sc.PartyLeader)
                .WithMany(s => s.BookingPartyLeaders)
                .HasForeignKey(sc => sc.PartyLeaderId);

            modelBuilder.Entity<PartyLeader>()
                .HasData(new PartyLeader { PartyLeaderId= Guid.Parse("D2FC8DEA-E40C-4B09-805C-B19C99991F24"),Name="AliBaba" });
            modelBuilder.Entity<PartyLeader>()
                .HasData(new PartyLeader { PartyLeaderId = Guid.Parse("5B8A57EE-B147-4F8C-B7E6-F8725119DEB4"), Name = "EliGasht" });
        }

    }

}
