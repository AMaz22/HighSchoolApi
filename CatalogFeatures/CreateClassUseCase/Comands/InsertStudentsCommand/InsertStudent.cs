using AutoMapper;
using CatalogFeatures.CreateClassUseCase.BusinessLogic.StudentLogic;
using EntityFrameworkORM.Models;
using Microsoft.Extensions.Logging;

namespace CatalogFeatures.CreateClassUseCase.Comands.InsertStudentsCommand
{
    public interface IInsertStudent
    {
        Task<InsertStudentResponse> InsertAsync(StudentProcessorResponse studentProcessorResponse);
    }
    public class InsertStudent : IInsertStudent
    {
        private readonly HighSchoolContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<InsertStudent> _logger;

        public InsertStudent(HighSchoolContext context, IMapper mapper, ILogger<InsertStudent> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<InsertStudentResponse> InsertAsync(StudentProcessorResponse studentProcessorResponse)
        {
            var response = new InsertStudentResponse();
            var studentEntity = _mapper.Map<Student>(studentProcessorResponse);
            try
            {
                await _context.Students.AddAsync(studentEntity);
                await _context.SaveChangesAsync();
                response.Inserted = true;

            }
            catch (Exception ex)
            {
                response.Inserted = false;
                response.ErrorMessage = ex.Message;
                _logger.LogError($"Failed to insert the student : {studentEntity}", studentEntity);
            }
            finally
            {
                response.Student = _mapper.Map<InsertStudentModel>(studentEntity);
            }
            return response;
        }
    }
}
