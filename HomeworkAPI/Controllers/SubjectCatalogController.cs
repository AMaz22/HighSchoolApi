using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SubjectFeatures.SubjectToCatalogFeature;

namespace HomeworkAPI.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]
    public class SubjectCatalogController : ControllerBase
    {
        private readonly IAssignSubjectToCatalog _subjectToCatalog;

        public SubjectCatalogController(IAssignSubjectToCatalog assignSubjectToCatalog)
        {
            _subjectToCatalog = assignSubjectToCatalog;
        }

        [HttpGet]
        public async Task<IActionResult> AssignToCatalog(int catalogId)
        {
            
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AssignToCatalog(SubjectCatalogModel model)
        {
            await _subjectToCatalog.Assign(model);
            return Ok();
        }
    }*/
}
