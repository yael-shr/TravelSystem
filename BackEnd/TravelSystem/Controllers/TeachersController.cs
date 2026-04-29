using Microsoft.AspNetCore.Mvc;
using TravelSystem.Entities;
using TravelSystem.Entities.Interfaces;
using TravelSystem.Services;

namespace TravelSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController(ITeacherService service) : ControllerBase
    {
            [HttpGet("all")]
            public async Task<IActionResult> GetAllTeacher()
            {
                var teachers = await service.GetAllTeachersAsync();
                return Ok(teachers);
            }

            [HttpGet("id/{id}")]
            public async Task<IActionResult> GetTeacherById(string id)
            {
                var teacher = await service.GetTeacherByIdAsync(id);
                if (teacher == null)
                    return NotFound();
                return Ok(teacher);
            }

            [HttpPost("add")]
            public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
            {
                if (teacher == null) return BadRequest();

                await service.AddTeacherAsync(teacher);
                return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.PersonalId }, teacher);
            }

            
    }
}
