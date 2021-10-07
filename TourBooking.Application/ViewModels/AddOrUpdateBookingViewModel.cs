using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static TourBooking.Application.Enumeration.Enumeration;

namespace TourBooking.Application.ViewModels
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
