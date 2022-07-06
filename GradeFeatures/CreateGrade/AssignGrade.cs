using GradeFeatures.CreateGrade.BusinessLogic.BusinessValidations;
using GradeFeatures.CreateGrade.Comands;
using HighSchoolShared.Exceptions.GradeExceptions;
using Microsoft.Extensions.Logging;

namespace GradeFeatures.CreateGrade
{
    public interface IAssignGrade
    {
        Task<InsertedGradeModel> Assign(AddGradeModel addGradeModel);
    }
    public class AssignGrade : IAssignGrade
    {
        private readonly ISubjectCatalogValidator _subjectCatalogValidator;
        private readonly IStudentValidator _studentValidator;
        private readonly IInsertGrade _insertGrade;
        private readonly ILogger<AssignGrade> _logger;

        public AssignGrade(ISubjectCatalogValidator subjectCatalogValidator, IStudentValidator studentValidator, IInsertGrade insertGrade,
            ILogger<AssignGrade> logger)
        {
            _subjectCatalogValidator = subjectCatalogValidator;
            _studentValidator = studentValidator;
            _insertGrade = insertGrade;
            _logger = logger;
        }

        public async Task<InsertedGradeModel> Assign(AddGradeModel addGradeModel)
        {
            // 1. Validate request data
            await ValideRequestData(addGradeModel);

            // 2. Validate business rules
            await ValidateBusinessRules(addGradeModel);

            // 3. Insert grade in the db
            var response = await _insertGrade.Insert(addGradeModel);

            return response;
        }

        private async Task ValideRequestData(AddGradeModel addGradeModel)
        {
            var validator = new AddGradeRequestDataValidator();
            var result = await validator.ValidateAsync(addGradeModel);
            if (!result.IsValid)
            {
                _logger.LogError($"Bad request at {DateTime.Now} when validating data from the request.");
                throw new AddGradeInvalidDataBadRequestException();
            }
        }
        private async Task ValidateBusinessRules(AddGradeModel addGradeModel)
        {
            await _studentValidator.Validate(addGradeModel);

            await _subjectCatalogValidator.Validate(addGradeModel);
        }
    }
}
