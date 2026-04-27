using Microsoft.AspNetCore.Mvc;
using TravelSystem.Entities;
using TravelSystem.Repositories.Interfaces;
using TravelSystem.Services;
using static TravelSystem.DTOs.LocationUpdateDTO;

namespace TravelSystem.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
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

        [HttpPost("update")]
        public async Task<IActionResult> UpdateLocation([FromBody] StudentLocationUpdateDTO location)
        {
            if (location == null) return BadRequest();
            var newLocation = service.MapToEntity(location);
            await repo.UpsertLocationAsync(newLocation);
            return Ok(new { message = "Location updated successfully" });
        }

        [HttpPost("all")]
        public async Task<IActionResult> GetAllLocation([FromBody]  List<Student> students)
        {
            if(!students.Any()) return BadRequest();
            List<Location> locations = await repo.GetAllLocation(students);
            return Ok(locations);
        }
    }
}
