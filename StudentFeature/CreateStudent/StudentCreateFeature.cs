using AutoMapper;
using EntityFrameworkORM.Models;

namespace StudentFeature.CreateStudent
{
    public interface IStudentCreateFeature
    {
        Task<bool> Create(StudentModel model);
    }

    public class StudentCreateFeature : IStudentCreateFeature
    {
        private readonly HighSchoolContext _context;
        private readonly IMapper _mapper;

        public StudentCreateFeature(HighSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<bool> Create(StudentModel model)
        {

            //Default value will be 9
            if (model.StudentYear < 9 || model.StudentYear > 12)
            {
                model.StudentYear = 9;
            }
            var validator = new StudentModelValidator();
            var result = validator.Validate(model);
            if (result.IsValid)
            {
                var student = _mapper.Map<Student>(model);
                await _context.Students.AddAsync(student);
                await _context.SaveChangesAsync();
            }
            return result.IsValid;
        }
    }
}
