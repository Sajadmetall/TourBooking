using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Domain.Entities;

namespace TourBooking.Infrastructure.EntityConfiguration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder
            .Property(b => b.Name)
            .IsRequired();
            builder
            .Property(b => b.CreateDate)
            .IsRequired();
            builder
            .Property(b => b.Status)
            .IsRequired();
        }
    }
}
