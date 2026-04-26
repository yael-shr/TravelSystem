using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelSystem.Core.Entities;
using TravelSystem.Core.Interfaces;

namespace TravelSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController(IStudentRepository repo) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await repo.GetAllAsync();
            return  Ok(students);  
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            var student = await repo.GetByIdAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet("group/{group}")]
        public async Task<IActionResult> GetStudentByGroup(string group)
        {
            var sudents = await repo.GetByClassAsync(group);
            if (sudents == null)
                return NotFound();
            return Ok(sudents);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (student == null) return BadRequest();

            await repo.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.PersonalId }, student);
        }

    }
}
