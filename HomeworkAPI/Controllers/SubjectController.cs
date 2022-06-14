using Microsoft.AspNetCore.Mvc;
using SubjectFeatures.AddSubjects;
using SubjectFeatures.GetSubjects;

namespace HomeworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly IAddSubject _addSubject;
        private readonly IGetSubject _getSubject;

        public SubjectController(IAddSubject addSubject, IGetSubject getSubject)
        {
            _addSubject = addSubject;
            _getSubject = getSubject;
        }

        [HttpGet("{id}")]
        public IActionResult GetSubjectByID(int id = 0)
        {
            var result = _getSubject.GetSubjectById(id);
            if(id != 0)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubject(SubjectModel model)
        {
            var result = await _addSubject.AddAsync(model);
            if (result)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
