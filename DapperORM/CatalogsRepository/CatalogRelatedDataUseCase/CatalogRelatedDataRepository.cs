using Dapper;

namespace DapperORM.CatalogsRepository.CatalogRelatedDataUseCase
{
    public interface ICatalogRelatedDataRepository
    {
        Task<CatalogRelatedDataDto> GetDataAsync(int pageIndex, int pageSize,
            int catalogId, string sortedOrder, string sortOrderType);
    }

    public class CatalogRelatedDataRepository : ICatalogRelatedDataRepository
    {
        private readonly IDapperRepository _repository;

        public CatalogRelatedDataRepository(IDapperRepository repository)
        {
            _repository = repository;
        }

        public async Task<CatalogRelatedDataDto> GetDataAsync(int pageIndex, int pageSize,
            int catalogId, string sortedOrder, string sortOrderType)
        {
            var storedProcedureParameters = new DynamicParameters();
            storedProcedureParameters.Add("@PageIndex", pageIndex);
            storedProcedureParameters.Add("@PageSize", pageSize);
            storedProcedureParameters.Add("@CatalogID", catalogId);
            storedProcedureParameters.Add("@SortedOrder", sortedOrder);
            storedProcedureParameters.Add("@SortOrderType", sortOrderType);

            var response = new CatalogRelatedDataDto();
            await _repository.QueryStoredProcedureAsync("dbo.DataRelatedToCatalog", (reader) =>
            {
                response.Details = reader.Read<CatalogDetails>().ToList();

            }, parameters: storedProcedureParameters);
            return response;
        }
    }
}
