using GradeFeatures.CreateGrade;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradeController : ControllerBase
    {
        private readonly IAssignGrade _assignGrade;

        public GradeController(IAssignGrade assignGrade)
        {
            _assignGrade = assignGrade;
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> CreateGrade(AddGradeModel addGradeModel)
        {
            var result = await _assignGrade.Assign(addGradeModel);
            return Created("", result);
        }
    }
}
