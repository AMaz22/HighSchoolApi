using AutoMapper;
using EntityFrameworkORM.Models;
using HighSchoolShared.Exceptions.GradeExceptions;
using Microsoft.Extensions.Logging;

namespace GradeFeatures.CreateGrade.Comands
{
    public interface IInsertGrade
    {
        Task<InsertedGradeModel> Insert(AddGradeModel addGradeModel);
    }
    public class InsertGrade : IInsertGrade
    {
        private readonly HighSchoolContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<InsertGrade> _logger;

        public InsertGrade(HighSchoolContext context, IMapper mapper, ILogger<InsertGrade> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InsertedGradeModel> Insert(AddGradeModel addGradeModel)
        {
            try
            {
                var gradeEntity = _mapper.Map<Grade>(addGradeModel);
                gradeEntity.GradeDate = DateTime.Now;
                await _context.Grades.AddAsync(gradeEntity);
                await _context.SaveChangesAsync();
                var result = _mapper.Map<InsertedGradeModel>(gradeEntity);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Error when inserting into grades: {@ex}", ex);
                throw new InsertGradeInternalServerErrorException("Error while inserting into grades!");
            }
        }
    }
}
