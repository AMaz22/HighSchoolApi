using Dapper;

namespace DapperORM.CatalogsRepository.ClassJoinCatalogUseCase
{
    public interface IClassJoinCatalogUseCaseRepository
    {
        Task<IEnumerable<ClassJoinCatalogDto>> GetClassJoinCatalogDto();
    }
    public class ClassJoinCatalogRepository
    {
        private readonly IDapperRepository _repository;

        public ClassJoinCatalogRepository(IDapperRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ClassJoinCatalogDto> GetClassJoinCatalogDto(int currentYear, bool activeCatalog = true)
        {
            var storedProcedureParameters = new DynamicParameters();
            storedProcedureParameters.Add("@CurrentYear", currentYear, System.Data.DbType.Int32);
            storedProcedureParameters.Add("@ActiveCatalog", activeCatalog, System.Data.DbType.Boolean);
            
            var response = new List<ClassJoinCatalogDto>();

            _repository.QueryStoredProcedure("dbo.GetSubjectById", (reader) =>
            {
                response = reader.Read<ClassJoinCatalogDto>().ToList();
                
            }, parameters: storedProcedureParameters);
            return response;
        }
    }
}
