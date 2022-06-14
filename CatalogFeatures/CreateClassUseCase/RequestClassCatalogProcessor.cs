using CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic;
using CatalogFeatures.CreateClassUseCase.Comands;

namespace CatalogFeatures.CreateClassUseCase
{
    public interface IRequestClassCatalogProcessor
    {
        public Task<ClassCatalogResponse> ProcessAsync(ClassCatalogStudentsRequest request);
    }

    public class RequestClassCatalogProcessor: IRequestClassCatalogProcessor
    {
        private readonly IClassRequestProcessor _classIngestor;
        private readonly IInsertClass _insertClass;
        private readonly IInsertCatalog _insertCatalog;

        public RequestClassCatalogProcessor(IClassRequestProcessor classIngestor, IInsertClass insertClass, IInsertCatalog insertCatalog)
        {
            _classIngestor = classIngestor;
            _insertClass = insertClass;
            _insertCatalog = insertCatalog;
        }

        public async Task<ClassCatalogResponse> ProcessAsync(ClassCatalogStudentsRequest request)
        {
            // 1. Validate Request data
            await ValidateRequest(request);

            // 2. Validate business rules
            //await ValidateBusinessRules(request);

            // 3. Get response class model
            var responseClassModel = await _classIngestor.ProcessRequestClassModel(request.ClassModel);

            // 4. Insert Class
            var classEntity = await _insertClass.Insert(responseClassModel);

            // 5. Insert Catalog
            var catalog = await _insertCatalog.Insert(classEntity);

            // 6. Insert Students

            return new ClassCatalogResponse();
        }
        private async Task ValidateRequest(ClassCatalogStudentsRequest request)
        {
            var validator = new ClassCatalogRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if(!validationResult.IsValid)
            {

            }
        }

        

    }
}
