using CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic;
using CatalogFeatures.CreateClassUseCase.BusinessLogic.StudentLogic;
using CatalogFeatures.CreateClassUseCase.Comands.InsertCatalogCommand;
using CatalogFeatures.CreateClassUseCase.Comands.InsertClassComand;
using CatalogFeatures.CreateClassUseCase.Comands.InsertStudentsCommand;
using CatalogFeatures.CreateClassUseCase.UseCaseResponseAndRequests;
using HighSchoolShared.Exceptions.CatalogExceptions;
using Microsoft.Extensions.Logging;

namespace CatalogFeatures.CreateClassUseCase
{
    public interface IRequestClassCatalogProcessor
    {
        public Task<UseCaseMainResponse> ProcessAsync(UseCaseMainRequest request);
    }

    public class UseCaseRequestProcessor : IRequestClassCatalogProcessor
    {
        private readonly IClassRequestProcessor _classIngestor;
        private readonly IInsertClass _insertClass;
        private readonly IInsertCatalog _insertCatalog;
        private readonly IInsertStudent _insertStudent;
        private readonly IStudentProcessor _studentProcessor;
        private readonly IResponseBuilder _responseBuilder;
        private readonly ILogger<UseCaseRequestProcessor> _logger;

        public UseCaseRequestProcessor(IClassRequestProcessor classIngestor, IInsertClass insertClass,
            IInsertCatalog insertCatalog, IStudentProcessor studentProcessor, IInsertStudent insertStudent,
            IResponseBuilder responseBuilder, ILogger<UseCaseRequestProcessor> logger)
        {
            _classIngestor = classIngestor;
            _insertClass = insertClass;
            _insertCatalog = insertCatalog;
            _insertStudent = insertStudent;
            _studentProcessor = studentProcessor;
            _responseBuilder = responseBuilder;
            _logger = logger;
        }

        public async Task<UseCaseMainResponse> ProcessAsync(UseCaseMainRequest request)
        {
            // 1. Validate Request data
            await ValidateRequest(request);

            // 2. Validate business rules
            await ValidateBusinessRules(request);

            // 3. Get response class model
            var processorClassModel = await ProccesClassData(request.ClassModel);

            // 4. Insert Class
            var insertClassResponse = await _insertClass.Insert(processorClassModel);

            // 5. Insert Catalog
            var insertCatalogResponse = await _insertCatalog.Insert(insertClassResponse);


            // 6. Handle Students request
            var insertedStudentsResponses = new List<InsertStudentResponse>();
            if (request.Students != null)
            {
                var studentProcessorResponses = ProcessStudentRequests(request.Students, insertCatalogResponse.CatalogModel.CatalogId);
                var insertStudents = await InsertStudents(studentProcessorResponses);
                insertedStudentsResponses.AddRange(insertStudents);
            }
            // 7. Build response
            var response = _responseBuilder.BuildResponse(insertClassResponse, insertCatalogResponse, insertedStudentsResponses);

            return response;
        }

        private async Task ValidateRequest(UseCaseMainRequest request)
        {
            var validator = new ClassCatalogRequestValidator();
            var validationResult = await validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                _logger.LogError($"Invalid input {request.ClassModel.CurrentYear} at {DateTime.Now} for creating a class with or not with students method");
                throw new CreateClassBadRequestException("Invalid year");
            }
        }
        private async Task ValidateBusinessRules(UseCaseMainRequest request)
        {
            
        }

        private async Task<ProcessorClassModel> ProccesClassData(RequestClassModel request)
        {
            return await _classIngestor.ProcessRequestClassModel(request);
        }

        private IEnumerable<StudentProcessorResponse> ProcessStudentRequests(IEnumerable<StudentApiRequest> studentsRequests, int CatalogId)
        {
            var studentResponses = new List<StudentProcessorResponse>();
            foreach (var request in studentsRequests)
            {
                var response = _studentProcessor.ProcessRequest(request);
                response.CatalogId = CatalogId;
                studentResponses.Add(response);
            }
            return studentResponses;
        }

        private async Task<IEnumerable<InsertStudentResponse>> InsertStudents(IEnumerable<StudentProcessorResponse> processorResponses)
        {
            var insertStudentsResponses = new List<InsertStudentResponse>();
            foreach (var processorResponse in processorResponses)
            {
                var response = await _insertStudent.InsertAsync(processorResponse);
                insertStudentsResponses.Add(response);
            }
            return insertStudentsResponses;
        }
    }
}
