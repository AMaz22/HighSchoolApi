using CatalogFeatures.CreateClassUseCase;
using CatalogFeatures.CreateClassUseCase.UseCaseResponseAndRequests;
using CatalogFeatures.DataRelatedToCatalogUseCase;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly IRequestClassCatalogProcessor _createClass;
        private readonly IGetDataFromCatalog _getDataFromCatalog;

        public CatalogController(IRequestClassCatalogProcessor createClass, IGetDataFromCatalog getDataFromCatalog)
        {
            _createClass = createClass;
            _getDataFromCatalog = getDataFromCatalog;
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<IActionResult> CreateClass(UseCaseMainRequest request)
        {
            var response = await _createClass.ProcessAsync(request);
            return Created("/CreateClass", response);
        }

        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<IActionResult> GetCatalogData(int pageIndex, int pageSize,
            int catalogId, string sortedOrder, string sortOrderType)
        {
            var response = await _getDataFromCatalog.GetDataAsync(pageIndex, pageSize, catalogId, sortedOrder, sortOrderType);
            return Ok(response);
        }
    }
}
