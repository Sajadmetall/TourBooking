using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static TourBooking.Application.Enumeration.BookingEnumeration;

namespace TourBooking.Application.ViewModels
{
    public class AddOrUpdateBookingViewModel
    {
        public Guid? BookingId { get; set; }
        public string Name { get; set; }
        public DateTime? CreateDate { get; set; }
        public BookingStatus? Status { get; set; }
        public string Price { get; set; }
        public BookingCurrency? Currency { get; set; }
        public List<PartyLeaderViewModel> PartyLeaders { get; set; }
    }
}
