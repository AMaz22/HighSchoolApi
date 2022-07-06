using AutoMapper;
using CatalogFeatures.CreateClassUseCase.UseCaseResponseAndRequests;

namespace CatalogFeatures.CreateClassUseCase.BusinessLogic.StudentLogic
{
    public interface IStudentProcessor
    {
        StudentProcessorResponse ProcessRequest(StudentApiRequest request);
    }
    public class StudentProcessor : IStudentProcessor
    {
        private readonly IMapper _mapper;

        public StudentProcessor(IMapper mapper)
        {
            _mapper = mapper;
        }
        public StudentProcessorResponse ProcessRequest(StudentApiRequest request)
        {
            var response = _mapper.Map<StudentProcessorResponse>(request);
            response.IsValidData = ValidateName(request.Name);
            if (response.IsValidData == false)
            {
                response.ErrorMessage = $"Invalid name {request.Name}";
            }
            return response;
        }

        private bool ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            return true;
        }
    }
}
