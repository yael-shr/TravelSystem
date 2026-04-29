using Microsoft.AspNetCore.Mvc;
using TravelSystem.Entities;
using TravelSystem.Entities.Interfaces;
using TravelSystem.Services;
using static TravelSystem.DTOs.LocationUpdateDTO;

namespace TravelSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LocationsController(ILocationService service) : ControllerBase
    {
        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetLocationById(string id)
        {
            var location = await service.GetLocationByIdAsync(id);
            if (location == null) return NotFound();
            return Ok(location);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateLocation([FromBody] StudentLocationUpdateDTO location)
        {
            if (location == null) return BadRequest();
            await service.UpdateLocationAsync(location);
            return Ok(new { message = "Location updated successfully" });
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAllLocation([FromBody] List<Student> students)
        {
            if (students == null || !students.Any()) return BadRequest();
            var locations = await service.GetAllLocationsAsync(students);
            return Ok(locations);
        }
    }
}