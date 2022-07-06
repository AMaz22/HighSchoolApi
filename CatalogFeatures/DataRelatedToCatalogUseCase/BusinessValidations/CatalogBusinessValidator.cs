using EntityFrameworkORM.Models;
using HighSchoolShared.Exceptions.CatalogExceptions;
using Microsoft.Extensions.Logging;

namespace CatalogFeatures.DataRelatedToCatalogUseCase.BusinessValidations
{
    public interface IGetDataCatalogValidator
    {
        Task ValidateAsync(int pageIndex, int pageSize,
            int catalogId, string sortedOrder, string sortOrderType);
    }
    public class CatalogBusinessValidator : IGetDataCatalogValidator
    {
        private readonly HighSchoolContext _context;
        private readonly ILogger<CatalogBusinessValidator> _logger;

        public CatalogBusinessValidator(HighSchoolContext context, ILogger<CatalogBusinessValidator> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task ValidateAsync(int pageIndex, int pageSize,
            int catalogId, string sortedOrder, string sortOrderType)
        {
            var validCatalogId = await ValidateCatalogIdAsync(catalogId);
            if (!validCatalogId)
            {
                _logger.LogError($"The catalog with the id : {catalogId} was not found in the db.");
                throw new GetCatalogByIdNotFoundException();
            }
        }

        private async Task<bool> ValidateCatalogIdAsync(int catalogId)
        {
            var result = await _context.Catalogs.FindAsync(catalogId);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
