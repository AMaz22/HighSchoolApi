using AutoMapper;
using EntityFrameworkORM.Models;

namespace CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic
{
    public interface IClassRequestProcessor
    {
        Task<ResponseClassModel> ProcessRequestClassModel(RequestClassModel requestClassModel);
    }

    public class ClassRequestProcessor: IClassRequestProcessor
    { 
        private readonly string[] RomanYears = { "XII", "XI", "X", "IX" };
        private const string AlphabetClass = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        private readonly HighSchoolContext _context;
        private readonly IMapper _mapper;
        private readonly IRequestClassValidator _requestClassValidator;

        public ClassRequestProcessor(HighSchoolContext context, IMapper mapper, IRequestClassValidator requestClassValidator)
        {
            _context = context;
            _mapper = mapper;
            _requestClassValidator = requestClassValidator;
        }

        public async Task<ResponseClassModel> ProcessRequestClassModel(RequestClassModel requestClassModel)
        {
            requestClassModel = _requestClassValidator.Validate(requestClassModel);

            var processedClassModel = _mapper.Map<ResponseClassModel>(requestClassModel);
            processedClassModel.ClassCicle = $"{processedClassModel.StartDate.Year} - {processedClassModel.StartDate.Year + 1}";
            processedClassModel.NameOfClass = GetAvailableClassName(processedClassModel);

            return processedClassModel;
        }
            
        private string GetAvailableClassName(ResponseClassModel response)
        {
            var existingClasses = _context.Classes.Where(c => c.CurrentYear == response.CurrentYear && c.ClassCicle == response.ClassCicle);
            string className = $"{RomanYears[12 - response.CurrentYear]} - {AlphabetClass[existingClasses.Count()]}";
            return className;
        }
    }
}
