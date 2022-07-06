using CatalogFeatures.CreateClassUseCase.Comands.InsertCatalogCommand;
using CatalogFeatures.CreateClassUseCase.Comands.InsertClassComand;
using CatalogFeatures.CreateClassUseCase.Comands.InsertStudentsCommand;
using Microsoft.Extensions.Logging;

namespace CatalogFeatures.CreateClassUseCase.UseCaseResponseAndRequests
{
    public interface IResponseBuilder
    {
        UseCaseMainResponse BuildResponse(InsertClassResponse insertClassResponse, InsertCatalogResponse insertCatalogResponse, List<InsertStudentResponse> insertStudentResponses = null);
    }
    public class ResponseBuilder : IResponseBuilder
    {
        private readonly ILogger<ResponseBuilder> _logger;

        public ResponseBuilder(ILogger<ResponseBuilder> logger)
        {
            _logger = logger;
        }
        public UseCaseMainResponse BuildResponse(InsertClassResponse insertClassResponse, InsertCatalogResponse insertCatalogResponse, List<InsertStudentResponse> insertStudentResponses = null)
        {
            var response = new UseCaseMainResponse();
            if(insertStudentResponses != null)
            {
                _logger.LogError("Students not null");
                response.StudentsResponses = insertStudentResponses;
            }
            response.ClassCatalogResponse = new ApiCatalogClassResponse()
            {
                TheCatalog = insertCatalogResponse,
                TheClass = insertClassResponse
            };
            return response;
        }
    }
}
