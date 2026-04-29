using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelSystem.DTOs;
using TravelSystem.Services;

namespace TravelSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthControler(TeacherService teacherService) : ControllerBase
    {
        //[HttpPost("login")]
        //public IActionResult Login(LoginDTO user)
        //{
        //    teacherService.ValidatUser(user);

        //}
    }
}
