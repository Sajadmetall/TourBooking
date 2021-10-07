using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TourBooking.Domain.Enumeration.Enumeration;

namespace TourBooking.Domain.ViewModels
{
    public class BookingViewModel
    {
        public Guid? BookingId { get; set; }
        
        public string Name { get; set; }
        public Nullable<DateTime> CreateDate { get; set; }
        public Nullable<BookingStatus> Status { get; set; }
        public string Price { get; set; }
        public Nullable<BookingCurrency> Currency { get; set; }
        public List<PartyLeaderViewModel> PartyLeaders { get; set; }
    }
}
