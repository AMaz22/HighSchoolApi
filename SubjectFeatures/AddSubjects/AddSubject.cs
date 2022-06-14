using AutoMapper;
using EntityFrameworkORM.Models;

namespace SubjectFeatures.AddSubjects
{
    public class AddSubject : IAddSubject
    {
        private readonly IMapper _mapper;
        private readonly HighSchoolContext _context;

        public AddSubject(IMapper mapper, HighSchoolContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<bool> AddAsync(SubjectModel model)
        {
            var validator = new AddSubjectValidation();
            var result = await validator.ValidateAsync(model);    
            if (result.IsValid)
            {
                var subject = _mapper.Map<Subject>(model);
                _context.Subjects.Add(subject);
                await _context.SaveChangesAsync();
            }
            return result.IsValid;
        }
    }
}
