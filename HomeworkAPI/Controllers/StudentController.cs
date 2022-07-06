using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentFeature.CreateStudent;
using StudentFeature.GetStudentForPaginationFeature;

namespace HomeworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentCreateFeature _studentCreateFeature;
        private readonly IGetStudentsForGrid _getStudentsForGrid;

        public StudentController(IStudentCreateFeature studentCreateFeature, IGetStudentsForGrid getStudentsForGrid)
        {
            _studentCreateFeature = studentCreateFeature;
            _getStudentsForGrid = getStudentsForGrid;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStudentAsync(StudentModel model)
        {
            var result = await _studentCreateFeature.Create(model);
            
            return Ok(result);
        }
        [HttpGet("StudentsForGrid")]
        public async Task<IActionResult> GetStudentsGridComplexAsync(int pageIndex, int pageSize,
            string orderColumn, string sortOrderType)
        {
            var result =  await _getStudentsForGrid.GetAsync(pageIndex, pageSize, orderColumn, sortOrderType);
            return Ok(result);
        }

    }
}
