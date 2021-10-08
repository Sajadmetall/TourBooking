using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourBooking.Application.ViewModels;
using TourBooking.Domain.Contracts;
using TourBooking.Domain.Entities;
using static TourBooking.Application.Enumeration.BookingEnumeration;

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
            return await _partyLeaderRepository.GetAllAsQueryable()
                .Select(x => new PartyLeaderViewModel
                {
                    PartyLeaderId = x.PartyLeaderId,
                    Name = x.Name
                }).ToListAsync();
        }
        public async Task<List<PartyLeaderViewModel>> GetPartyLeadersByBookingId(Guid bookingId)
        {
            var result = await _partyLeaderRepository.GetAllAsQueryable()
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
            var bookingItems = _bookingRepository.GetAllAsQueryable();

            if (!string.IsNullOrEmpty(booking.Name))
                bookingItems = bookingItems.Where(x => x.Name.Contains(booking.Name));

            if (booking.Status != null)
                bookingItems = bookingItems.Where(x => x.Status == (int)booking.Status);
            return await bookingItems.Select(x => new BookingViewModel
            {
                BookingId = x.BookingId,
                CreateDate = x.CreateDate,
                Currency = (BookingCurrency?)x.Currency,
                CurrencyText = BookingViewModel.SetCurrencyText((BookingCurrency)x.Currency),
                Price = x.Price,
                Status = (BookingStatus?)x.Status,
                StatusText = BookingViewModel.SetStatusText((BookingStatus)x.Status),
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
            var booking = Booking.AddBooking(Guid.NewGuid(), bookingViewModel.Name, DateTime.Now, (Int16)bookingViewModel.Status,
                bookingViewModel.Price, (Int16)bookingViewModel.Currency);

            booking.BookingPartyLeaders = bookingViewModel.PartyLeaders.Select(x => new BookingPartyLeader
            {
                BookingId = booking.BookingId,
                PartyLeaderId = x.PartyLeaderId.GetValueOrDefault()
            }).ToList();
            _bookingRepository.Insert(booking);
            return await _bookingRepository.SaveChangesAsync();
        }
        public async Task<int> UpdateBooking(AddOrUpdateBookingViewModel bookingViewModel)
        {
            var booking = await _bookingRepository.GetAllAsQueryable().Where(x => x.BookingId == bookingViewModel.BookingId)
                .Include(x => x.BookingPartyLeaders)
                .Where(x => x.BookingId == bookingViewModel.BookingId).SingleOrDefaultAsync();

            booking = Booking.UpdateBooking(bookingViewModel.BookingId.GetValueOrDefault(), bookingViewModel.Name, bookingViewModel.CreateDate.GetValueOrDefault(),
            booking.Status, (short)bookingViewModel.Status, bookingViewModel.Price,
            (short)bookingViewModel.Currency);


            booking.BookingPartyLeaders = bookingViewModel.PartyLeaders.Select(x => new BookingPartyLeader
            {
                BookingId = booking.BookingId,
                PartyLeaderId = x.PartyLeaderId.GetValueOrDefault()
            }).ToList();

            _bookingRepository.Update(booking);
            return await _bookingRepository.SaveChangesAsync();

        }

    }
}
