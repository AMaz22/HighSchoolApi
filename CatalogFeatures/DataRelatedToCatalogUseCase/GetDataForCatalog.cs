using AutoMapper;
using CatalogFeatures.DataRelatedToCatalogUseCase.BusinessValidations;
using DapperORM.CatalogsRepository.CatalogRelatedDataUseCase;
using Microsoft.Extensions.Logging;

namespace CatalogFeatures.DataRelatedToCatalogUseCase
{
    public interface IGetDataFromCatalog
    {
        Task<CatalogRelatedDataModel> GetDataAsync(int pageIndex, int pageSize,
            int catalogId, string sortedOrder, string sortOrderType);
    }
    public class GetDataForCatalog : IGetDataFromCatalog
    {
        private readonly IGetDataCatalogValidator _catalogModelValidator;
        private readonly ICatalogRelatedDataRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetDataForCatalog> _logger;

        public GetDataForCatalog(IGetDataCatalogValidator catalogModelValidator, IMapper mapper,
            ICatalogRelatedDataRepository repository, ILogger<GetDataForCatalog> logger)
        {
            _catalogModelValidator = catalogModelValidator;
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<CatalogRelatedDataModel> GetDataAsync(int pageIndex, int pageSize,
            int catalogId, string sortedOrder, string sortOrderType)
        {
            // 1. Validate request


            // 2. Validate Business Rules

            // 3. Get Data from the db
            var result = await _repository.GetDataAsync(pageIndex, pageSize, catalogId, sortedOrder, sortOrderType);
            var response = new CatalogRelatedDataModel();
            response.Details = _mapper.Map<List<DataRelatedToCatalogDetails>>(result.Details);

            return response;
        }
    }
}
