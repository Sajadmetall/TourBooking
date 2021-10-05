using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourBooking.Data.Entities;
using TourBooking.Data.Repositories;
using TourBooking.Domain.ViewModels;
using static TourBooking.Domain.Enumeration.Enumeration;

namespace TourBooking.Domain.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public async Task<int> AddBooking(BookingViewModel bookingViewModel)
        {
            try
            {
                var selectedPartyLeaders = new List<BookingViewModel>();

                var booking = SetBookingModel(bookingViewModel);
                _bookingRepository.Insert(booking);
                return await _bookingRepository.SaveChangesAsync();
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<Booking>> GetBookings(BookingViewModel booking)
        {
            var bookingItems = _bookingRepository.GetAllAsQueryAble();
            if (!string.IsNullOrEmpty(booking.Name))
                bookingItems = bookingItems.Where(x => x.Name.Contains(booking.Name));
            
            if (booking.Status != null)
                bookingItems = bookingItems.Where(x => x.Status == (int)booking.Status);
            return await bookingItems.ToListAsync();

        }

        public async Task<int> RemoveBooking(Guid bookingId)
        {
            var objBooking=_bookingRepository.GetById(bookingId);
            _bookingRepository.Delete(objBooking);
            return await _bookingRepository.SaveChangesAsync();
        }

        public async Task<int> UpdateBooking(BookingViewModel bookingViewModel)
        {
            try 
            {
                var booking =await _bookingRepository.GetAllAsQueryAble()
                    .Include(x=>x.BookingPartyLeaders)
                    .Where(x=>x.BookingId==bookingViewModel.BookingId).SingleOrDefaultAsync();//SetBookingModel(bookingViewModel);
                booking.Name = bookingViewModel.Name;
                booking.Currency = (Int16)bookingViewModel.Currency.GetValueOrDefault();
                
                booking.Status = (booking.Status==  (Int16)BookingStatus.Canceled || booking.Status==(Int16)BookingStatus.Confirmed ) 
                                            && bookingViewModel.Status== (Int16)BookingStatus.Temporary ?booking.Status: (Int16)bookingViewModel.Status;
                booking.Price = bookingViewModel.Price;
                booking.BookingPartyLeaders= bookingViewModel.PartyLeaders.Select(x => new BookingPartyLeader
                {
                    PartyLeaderId = x.PartyLeaderId.GetValueOrDefault(),
                    BookingId = booking.BookingId
                }).ToList();
                _bookingRepository.Update(booking);
                return await _bookingRepository.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        private Booking SetBookingModel(BookingViewModel bookingViewModel)
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
