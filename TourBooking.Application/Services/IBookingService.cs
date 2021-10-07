using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TourBooking.Application.ViewModels;

namespace TourBooking.Application.Services
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
