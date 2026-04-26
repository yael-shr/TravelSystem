using Microsoft.AspNetCore.Mvc;
using TravelSystem.Core.Entities;
using TravelSystem.Core.Interfaces;
using TravelSystem.Services;

namespace TravelSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TeachersController(ITeacherRepository repo) : ControllerBase
    {
            [HttpGet("all")]
            public async Task<IActionResult> GetAllTeacher()
            {
                var teachers = await repo.GetAllAsync();
                return Ok(teachers);
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetTeacherById(string id)
            {
                var teacher = await repo.GetByIdAsync(id);
                if (teacher == null)
                    return NotFound();
                return Ok(teacher);
            }

            [HttpPost("add")]
            public async Task<IActionResult> AddStudent([FromBody] Teacher teacher)
            {
                if (teacher == null) return BadRequest();

                await repo.AddTeacherAsync(teacher);
                return CreatedAtAction(nameof(GetTeacherById), new { id = teacher.PersonalId }, teacher);
            }

            
    }
}
