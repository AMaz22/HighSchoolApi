using CatalogFeatures.CreateClassUseCase.Comands.InsertCatalogCommand;
using CatalogFeatures.CreateClassUseCase.Comands.InsertClassComand;

namespace CatalogFeatures.CreateClassUseCase.UseCaseResponseAndRequests
{
    public class ApiCatalogClassResponse
    {
        public InsertCatalogResponse TheCatalog { get; set; }
        public InsertClassResponse TheClass { get; set; }
    }
}
