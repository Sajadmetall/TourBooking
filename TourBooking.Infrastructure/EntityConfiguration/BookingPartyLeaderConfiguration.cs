using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TourBooking.Infrastructure.Entities;

namespace TourBooking.Infrastructure.EntityConfiguration
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
