using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBooking.Domain.Entities
{
    public class BookingPartyLeader
    {
        public Guid BookingId { get; set; }
        public Booking Booking { get; set; }

        public Guid PartyLeaderId { get; set; }
        public PartyLeader PartyLeader { get; set; }
    }
}
