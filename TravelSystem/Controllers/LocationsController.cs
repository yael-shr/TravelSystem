using Microsoft.AspNetCore.Mvc;
using TravelSystem.Core.Entities;
using TravelSystem.Core.Interfaces;
using TravelSystem.Services;
using static TravelSystem.Core.DTOs.LocationUpdateDTO;

namespace TravelSystem.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class LocationsController(ILocationRepository repo , LocationService service) : ControllerBase
    {
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetLocationById(string id)
        {
           
            var location = await repo.GetLocationAsync(id);
            if (location == null)
                return NotFound();
            return Ok(location);
        }
        [HttpPost("add")]
        public async Task<IActionResult> AddLocation([FromBody] StudentLocationUpdateDTO location)
        {
            if (location == null) return BadRequest();
            var newLocation = service.MapToEntity(location);
            await repo.AddLocationAsync(newLocation);
            return CreatedAtAction(nameof(GetLocationById), new { id = newLocation.PersonalId }, location);
        }
    }
}
