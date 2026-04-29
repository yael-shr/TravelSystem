using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TravelSystem.Entities;
using TravelSystem.Entities.Interfaces;

namespace TravelSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController(IStudentService service) : ControllerBase
    {
        [HttpGet("all")]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await service.GetAllStudentsAsync();
            return  Ok(students);  
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> GetStudentById(string id)
        {
            var student = await service.GetStudentByIdAsync(id);
            if (student == null)
                return NotFound();
            return Ok(student);
        }

        [HttpGet("group/{group}")]
        public async Task<IActionResult> GetStudentByGroup(string group)
        {
            var sudents = await service.GetStudentsByGroupAsync(group);
            if (sudents == null)
                return NotFound();
            return Ok(sudents);
        }

      
        [HttpPost("add")]
        public async Task<IActionResult> AddStudent([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            await service.AddStudentAsync(student);
            return CreatedAtAction(nameof(GetStudentById), new { id = student.PersonalId }, student);
        }

    }
}
