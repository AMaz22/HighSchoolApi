using EntityFrameworkORM.Models;
using HighSchoolShared.Exceptions.StudentsExceptions;
using Microsoft.Extensions.Logging;

namespace GradeFeatures.CreateGrade.BusinessLogic.BusinessValidations
{
    public interface IStudentValidator
    {
        Task Validate(AddGradeModel addGradeModel);
    }
    public class StudentValidator : IStudentValidator
    {
        private readonly HighSchoolContext _context;
        private readonly ILogger<StudentValidator> _logger;

        public StudentValidator(HighSchoolContext context, ILogger<StudentValidator> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Validate(AddGradeModel addGradeModel)
        {
            var resultStudent = await ValidateStudentId(addGradeModel.SubjectCatalogId);
            if (!resultStudent)
            {
                _logger.LogError($"The student id : {addGradeModel.StudentId} was not found in the db.");
                throw new InvalidStudentIdBadRequestException();
            }
        }
        private async Task<bool> ValidateStudentId(int subjectCatalogId)
        {
            var result = await _context.SubjectsCatalogs.FindAsync(subjectCatalogId);
            if (result != null)
            {
                return true;
            }
            return false;
        }
    }
}
