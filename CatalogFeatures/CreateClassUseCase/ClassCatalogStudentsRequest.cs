using CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic;

namespace CatalogFeatures.CreateClassUseCase
{
    public class ClassCatalogStudentsRequest
    {
        public RequestClassModel ClassModel { get; set; } = null!;
        public IEnumerable<StudentRequest>? Students { get; set; } = null;
    }
}
