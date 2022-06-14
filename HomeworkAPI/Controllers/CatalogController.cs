using CatalogFeatures.CreateClassUseCase;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IRequestClassCatalogProcessor _createClass;

        public CatalogController(IRequestClassCatalogProcessor createClass)
        {
            _createClass = createClass;
        }

        [HttpPost]
        public async Task<IActionResult> CreateClass(ClassCatalogStudentsRequest request)
        {
            var response = await _createClass.ProcessAsync(request);
            return Ok(response);
        }
    }
}
