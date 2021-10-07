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
        Task<List<PartyLeaderViewModel>> GetPartyLeaders();
        Task<List<PartyLeaderViewModel>> GetPartyLeadersByBookingId(Guid bookingId);
        Task<List<BookingViewModel>> GetBookings(BookingViewModel bookingViewModel);
        Task<int> AddBooking(AddOrUpdateBookingViewModel bookingViewModel);
        Task<int> UpdateBooking(AddOrUpdateBookingViewModel bookingViewModel);
        Task<int> RemoveBooking(Guid bookingId);

    }
}
