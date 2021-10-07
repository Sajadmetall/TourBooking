
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Net;
using System.Threading.Tasks;
using TourBooking.Application.Services;
using TourBooking.Application.ViewModels;
using TourBooking.Application.ViewModelValidators;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TourBooking.Controllers
{
    [EnableCors("CorsPolicy")]
    [ApiVersion("1.0")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private AddOrUpdateBookingViewModelValidator validator;
        public BookingController(IBookingService bookingService)
        {
            validator = new AddOrUpdateBookingViewModelValidator();
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
            if (result != null)
                return Ok(result);
            else
                return NotFound();
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
            if (validator.Validate(model).IsValid)
            {

                await _bookingService.AddBooking(model);
                return Ok(HttpStatusCode.OK);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut("UpdateBooking")]
        public async Task<IActionResult> UpdateBooking(AddOrUpdateBookingViewModel model)
        {
            if (validator.Validate(model).IsValid)
            {

                await _bookingService.UpdateBooking(model);
                return Ok(HttpStatusCode.OK);
            }
            else
            {
                return BadRequest();
            }
        }


        // DELETE api/<BookingController>/5
        [HttpDelete("DeleteBooking")]
        public async Task<IActionResult> DeleteBooking(Guid id)
        {
            await _bookingService.RemoveBooking(id);
            return Ok(HttpStatusCode.Accepted);

        }
    }
}
