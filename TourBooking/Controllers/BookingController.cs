using Charisma.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using TourBooking.Data.Entities;
using TourBooking.Domain.Services;
using TourBooking.Domain.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TourBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }
        // GET: api/<BookingController>
        [HttpGet]
        public async Task<IActionResult> GetBooking(BookingViewModel model)
        {
            var result = await _bookingService.GetBookings(model);
            return Ok(result);
        }

        // POST api/<BookingController>
        [HttpPost("AddBooking")]
        public async Task<IActionResult> AddBooking(BookingViewModel model)
        {
            if (ModelState.IsValid)
            {

                await _bookingService.AddBooking(model);
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
        [HttpPost("UpdateBooking")]
        public async Task<IActionResult> UpdateBooking( BookingViewModel model)
        {
            if (ModelState.IsValid)
            {

                await _bookingService.UpdateBooking(model);
                return Ok(true);
            }
            else
            {
                return Ok(false);
            }
        }
       

        // DELETE api/<BookingController>/5
        [HttpDelete("DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            await _bookingService.RemoveBooking(id);
            return Ok(true);

        }
    }
}
