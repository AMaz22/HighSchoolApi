using Microsoft.AspNetCore.Mvc;
using StudentFeature.CreateStudent;

namespace HomeworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentCreateFeature _studentCreateFeature;

        public StudentController(IStudentCreateFeature studentCreateFeature)
        {
            _studentCreateFeature = studentCreateFeature;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentModel model)
        {
            var result = await _studentCreateFeature.Create(model);
            
            return Ok(result);
        }

    }
}
