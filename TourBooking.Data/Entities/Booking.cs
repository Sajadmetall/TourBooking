using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBooking.Data.Entities
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required]
        public Int16 Status { get; set; }
        public string Price { get; set; }
        public Nullable<Int16> Currency { get; set; }
        public ICollection<BookingPartyLeader> BookingPartyLeaders { get; set; }


    }
}
