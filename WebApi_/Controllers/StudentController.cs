using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] getStudentNames = new string[] { "john", "doe", "jane" };
            return Ok(getStudentNames);
        }
    }
}
