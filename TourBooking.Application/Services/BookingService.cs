using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Application.ViewModels;
using TourBooking.Data.Entities;
using TourBooking.Data.Repositories;
using static TourBooking.Application.Enumeration.Enumeration;

namespace TourBooking.Application.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IPartyLeaderRepository _partyLeaderRepository;
        public BookingService(IBookingRepository bookingRepository,
            IPartyLeaderRepository partyLeaderRepository)
        {
            _bookingRepository = bookingRepository;
            _partyLeaderRepository = partyLeaderRepository;
        }

        public async Task<List<PartyLeaderViewModel>> GetPartyLeaders()
        {
            return await _partyLeaderRepository.GetAllAsQueryAble()
                .Select(x => new PartyLeaderViewModel
                {
                    PartyLeaderId = x.PartyLeaderId,
                    Name = x.Name
                }).ToListAsync();
        }
        public async Task<List<PartyLeaderViewModel>> GetPartyLeadersByBookingId(Guid bookingId)
        {
            var result = await _partyLeaderRepository.GetAllAsQueryAble()
                .Include(x => x.BookingPartyLeaders)
                .Where(x => x.BookingPartyLeaders.Any(y => y.BookingId == bookingId))
                .Select(x => new PartyLeaderViewModel
                {
                    PartyLeaderId = x.PartyLeaderId,
                    Name = x.Name
                }).ToListAsync();
            return result;
        }
        public async Task<List<BookingViewModel>> GetBookings(BookingViewModel booking)
        {
            var bookingItems = _bookingRepository.GetAllAsQueryAble();

            if (!string.IsNullOrEmpty(booking.Name))
                bookingItems = bookingItems.Where(x => x.Name.Contains(booking.Name));

            if (booking.Status != null)
                bookingItems = bookingItems.Where(x => x.Status == (int)booking.Status);
            return await bookingItems.Select(x => new BookingViewModel
            {
                BookingId = x.BookingId,
                CreateDate = x.CreateDate,
                Currency = (BookingCurrency?)x.Currency,
                Price = x.Price,
                Status = (BookingStatus?)x.Status,
                Name = x.Name
            }).ToListAsync();

        }

        public async Task<int> RemoveBooking(Guid bookingId)
        {
            var objBooking = _bookingRepository.GetById(bookingId);
            _bookingRepository.Delete(objBooking);
            return await _bookingRepository.SaveChangesAsync();
        }
        public async Task<int> AddBooking(AddOrUpdateBookingViewModel bookingViewModel)
        {
            var booking = SetBookingModel(bookingViewModel);
            _bookingRepository.Insert(booking);
            return await _bookingRepository.SaveChangesAsync();
        }
        public async Task<int> UpdateBooking(AddOrUpdateBookingViewModel bookingViewModel)
        {
            var booking = await _bookingRepository.GetAllAsQueryAble().Where(x => x.BookingId == bookingViewModel.BookingId)
                .Include(x => x.BookingPartyLeaders)
                .Where(x => x.BookingId == bookingViewModel.BookingId).SingleOrDefaultAsync();//SetBookingModel(bookingViewModel);

            booking.Name = bookingViewModel.Name;
            booking.Currency = (Int16)bookingViewModel.Currency.GetValueOrDefault();

            booking.Status = (booking.Status == (Int16)BookingStatus.Canceled || booking.Status == (Int16)BookingStatus.Confirmed)
                                        && bookingViewModel.Status == (Int16)BookingStatus.Temporary ? booking.Status : (Int16)bookingViewModel.Status;
            booking.Price = bookingViewModel.Price;
            if (bookingViewModel.PartyLeaders != null)
            {
                booking.BookingPartyLeaders = bookingViewModel.PartyLeaders.Select(x => new BookingPartyLeader
                {
                    PartyLeaderId = x.PartyLeaderId.GetValueOrDefault(),
                    BookingId = booking.BookingId
                }).ToList();
            }

            _bookingRepository.Update(booking);
            return await _bookingRepository.SaveChangesAsync();


        }
        private Booking SetBookingModel(AddOrUpdateBookingViewModel bookingViewModel)
        {
            var booking = new Booking
            {
                BookingId = Guid.NewGuid(),
                Name = bookingViewModel.Name,
                CreateDate = DateTime.Now,
                Status = (Int16)bookingViewModel.Status.GetValueOrDefault(),
                Currency = (Int16)bookingViewModel.Currency.GetValueOrDefault(),
                Price = bookingViewModel.Price

            };
            booking.BookingPartyLeaders = bookingViewModel.PartyLeaders.Select(x => new BookingPartyLeader
            {
                PartyLeaderId = x.PartyLeaderId.GetValueOrDefault(),
                BookingId = booking.BookingId
            }).ToList();
            return booking;
        }
    }
}
