using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourBooking.Domain.Entities
{
    public class Booking
    {
        public Guid BookingId { get;  set; }
        [Required]
        public string Name { get;  set; }
        [Required]
        public DateTime CreateDate { get;  set; }
        [Required]
        public Int16 Status { get;  set; }
        public string Price { get;  set; }
        public Nullable<Int16> Currency { get; set; }
        public ICollection<BookingPartyLeader> BookingPartyLeaders { get; set; }

        public static Booking AddBooking(Guid bookingId, string name, DateTime createDate, Int16 status, string price, Nullable<Int16> currency )
        {
            var booking = new Booking(bookingId, name, createDate, status, price, currency);
            return booking;
        }
        public static Booking UpdateBooking(Guid bookingId, string name, DateTime createDate, Int16 status, string price, Nullable<Int16> currency )
        {
            var booking = new Booking(bookingId, name, createDate, status, price, currency);
            return booking;
        }
        
        private Booking(Guid bookingId,string name, DateTime createDate, Int16 status, string price, Nullable<Int16> currency)
        {
            BookingId = bookingId;
            Name = name;
            CreateDate = createDate;
            Status = status;
            Price = price;
            Currency = currency;
        }


    }
}
