using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Data.Entities;

namespace TourBooking.Data.EntityConfiguration
{
    public class BookingPartyLeaderConfiguration : IEntityTypeConfiguration<BookingPartyLeader>
    {
        public void Configure(EntityTypeBuilder<BookingPartyLeader> builder)
        {
            builder.HasKey(sc => new { sc.BookingId, sc.PartyLeaderId });

            builder
                .HasOne(sc => sc.Booking)
                .WithMany(s => s.BookingPartyLeaders)
                .HasForeignKey(sc => sc.BookingId);


            builder
                .HasOne(sc => sc.PartyLeader)
                .WithMany(s => s.BookingPartyLeaders)
                .HasForeignKey(sc => sc.PartyLeaderId);
        }
    }
}
