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
    public class PartyLeaderConfiguration : IEntityTypeConfiguration<PartyLeader>
    {
        public void Configure(EntityTypeBuilder<PartyLeader> builder)
        {
            builder
                .HasData(new PartyLeader { PartyLeaderId = Guid.Parse("D2FC8DEA-E40C-4B09-805C-B19C99991F24"), Name = "AliBaba" });
            builder
                .HasData(new PartyLeader { PartyLeaderId = Guid.Parse("5B8A57EE-B147-4F8C-B7E6-F8725119DEB4"), Name = "EliGasht" });
        }
    }
}
