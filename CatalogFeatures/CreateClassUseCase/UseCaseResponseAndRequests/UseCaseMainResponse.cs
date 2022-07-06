using CatalogFeatures.CreateClassUseCase.Comands.InsertStudentsCommand;

namespace CatalogFeatures.CreateClassUseCase.UseCaseResponseAndRequests
{
    public class UseCaseMainResponse
    {
        public List<InsertStudentResponse>? StudentsResponses { get; set; }
        public ApiCatalogClassResponse ClassCatalogResponse { get; set; }
    }
}
