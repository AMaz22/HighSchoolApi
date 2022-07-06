using CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic;

namespace CatalogFeatures.CreateClassUseCase.UseCaseResponseAndRequests
{
    public class UseCaseMainRequest
    {
        public RequestClassModel ClassModel { get; set; } = null!;
        public IEnumerable<StudentApiRequest>? Students { get; set; } = null;
    }
}
