using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBooking.Infrastructure.Entities
{
    public class PartyLeader
    {
        public Guid PartyLeaderId { get; set; }
        public string Name { get; set; }
        public ICollection<BookingPartyLeader> BookingPartyLeaders { get; set; }
    }
}
