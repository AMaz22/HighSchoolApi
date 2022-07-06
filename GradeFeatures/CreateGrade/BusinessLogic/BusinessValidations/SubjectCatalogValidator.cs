using EntityFrameworkORM.Models;
using HighSchoolShared.Exceptions.GradeExceptions;
using Microsoft.Extensions.Logging;

namespace GradeFeatures.CreateGrade.BusinessLogic.BusinessValidations
{
    public interface ISubjectCatalogValidator
    {
        Task Validate(AddGradeModel addGradeModel);
    }
    public class SubjectCatalogValidator : ISubjectCatalogValidator
    {
        private readonly HighSchoolContext _context;
        private readonly ILogger<SubjectCatalogValidator> _logger;

        public SubjectCatalogValidator(HighSchoolContext context, ILogger<SubjectCatalogValidator> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Validate(AddGradeModel addGradeModel)
        {
            var resultSubjectCatalog = await ValidateSubjectCatalogId(addGradeModel.SubjectCatalogId);
            if (resultSubjectCatalog != true)
            {
                _logger.LogError($"The subjectCatalog id : {addGradeModel.SubjectCatalogId} was not found in the db.");
                throw new InvalidSubjectCatalogIdBadRequestException();
            }
        }
        private async Task<bool> ValidateSubjectCatalogId(int subjectCatalogId)
        {
            var result  = await _context.SubjectsCatalogs.FindAsync(subjectCatalogId);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
