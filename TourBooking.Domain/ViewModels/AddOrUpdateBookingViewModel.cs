using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Data.Entities;
using static TourBooking.Domain.Enumeration.Enumeration;

namespace TourBooking.Domain.ViewModels
{
    public class AddOrUpdateBookingViewModel
    {
        public Guid? BookingId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Nullable<DateTime> CreateDate { get; set; }
        [Required]
        public Nullable<BookingStatus> Status { get; set; }
        public string Price { get; set; }
        public Nullable<BookingCurrency> Currency { get; set; }
        public List<PartyLeaderViewModel> PartyLeaders { get; set; }
    }
}
