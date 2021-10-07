using Charisma.Domain.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using TourBooking.Data.Entities;
using TourBooking.Domain.Services;
using TourBooking.Domain.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TourBooking.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("GetPartyLeaders")]
        public async Task<IActionResult> GetPartyLeaders()
        {
            var result = await _bookingService.GetPartyLeaders();
            return Ok(result);
        }
        [HttpGet("GetPartyLeadersByBookingId")]
        public async Task<IActionResult> GetPartyLeadersByBookingId(Guid bookingId)
        {
            var result = await _bookingService.GetPartyLeadersByBookingId(bookingId);
            return Ok(result);
        }
        // GET: api/<BookingController>
        [HttpGet("GetBooking")]
        public async Task<IActionResult> GetBooking([FromQuery] BookingViewModel model)
        {
            var result = await _bookingService.GetBookings(model);
            return Ok(result);
        }

        // POST api/<BookingController>
        [HttpPost("AddBooking")]
        public async Task<IActionResult> AddBooking(AddOrUpdateBookingViewModel model)
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
        [HttpPut("UpdateBooking")]
        public async Task<IActionResult> UpdateBooking(AddOrUpdateBookingViewModel model)
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
