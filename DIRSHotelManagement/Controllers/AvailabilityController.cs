using DIRSHotelManagement.Interfaces;
using DIRSHotelManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace DIRSHotelManagement.Controllers
{

    [ApiController]
    [Route("api/availability")]
    public class AvailabilityController : ControllerBase
    {
        private readonly IAvailabilityRepository _availabilityRepository;

        public AvailabilityController(IAvailabilityRepository availabilityRepository)
        {
            _availabilityRepository = availabilityRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CheckAvailability([FromBody] Availability availabilityRequest)
        {
            if (availabilityRequest == null || string.IsNullOrEmpty(availabilityRequest.ProductId))
            {
                return BadRequest();
            }

            var isAvailable = await _availabilityRepository.CheckAvailability(
                availabilityRequest.ProductId,
                availabilityRequest.StartDate,
                availabilityRequest.EndDate);

            return Ok(isAvailable);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddAvailability([FromBody] Availability availability)
        {
            if (availability == null)
            {
                return BadRequest();
            }

            await _availabilityRepository.AddAvailability(availability);
            return CreatedAtAction(nameof(CheckAvailability), new { id = availability.Id }, availability);
        }
    }
}
