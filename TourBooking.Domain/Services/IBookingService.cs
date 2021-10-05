using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Data.Entities;
using TourBooking.Domain.ViewModels;

namespace TourBooking.Domain.Services
{
    public interface IBookingService
    {
        Task<List<Booking>> GetBookings(BookingViewModel bookingViewModel);
        Task<int> AddBooking(BookingViewModel bookingViewModel);
        Task<int> UpdateBooking(BookingViewModel bookingViewModel);
        Task<int> RemoveBooking(Guid bookingId);

    }
}
