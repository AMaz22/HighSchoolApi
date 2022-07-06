using AutoMapper;
using EntityFrameworkORM.Models;

namespace CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic
{
    public interface IClassRequestProcessor
    {
        Task<ProcessorClassModel> ProcessRequestClassModel(RequestClassModel requestClassModel);
    }

    public class ClassRequestProcessor: IClassRequestProcessor
    { 
        private readonly string[] RomanYears = { "XII", "XI", "X", "IX" };
        private const string AlphabetClass = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private readonly HighSchoolContext _context;
        private readonly IMapper _mapper;
        private readonly IRequestHandler _requestClassValidator;

        public ClassRequestProcessor(HighSchoolContext context, IMapper mapper, IRequestHandler requestClassValidator)
        {
            _context = context;
            _mapper = mapper;
            _requestClassValidator = requestClassValidator;
        }

        public async Task<ProcessorClassModel> ProcessRequestClassModel(RequestClassModel requestClassModel)
        {
            requestClassModel = _requestClassValidator.Handle(requestClassModel);

            var processedClassModel = _mapper.Map<ProcessorClassModel>(requestClassModel);
            processedClassModel.ClassCicle = $"{processedClassModel.StartDate.Year} - {processedClassModel.StartDate.Year + 1}";
            processedClassModel.NameOfClass = GetAvailableClassName(processedClassModel);

            return processedClassModel;
        }
            
        private string GetAvailableClassName(ProcessorClassModel response)
        {
            var existingClasses = _context.Classes.Where(c => c.CurrentYear == response.CurrentYear && c.ClassCicle == response.ClassCicle);
            string className = $"{RomanYears[12 - response.CurrentYear]} - {AlphabetClass[existingClasses.Count()]}";
            return className;
        }
    }
}
