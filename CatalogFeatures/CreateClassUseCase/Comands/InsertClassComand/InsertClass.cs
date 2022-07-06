using AutoMapper;
using CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic;
using EntityFrameworkORM.Models;
using HighSchoolShared.Exceptions.CatalogExceptions;
using Microsoft.Extensions.Logging;

namespace CatalogFeatures.CreateClassUseCase.Comands.InsertClassComand
{
    public interface IInsertClass
    {
        Task<InsertClassResponse> Insert(ProcessorClassModel classModel);
    }

    public class InsertClass : IInsertClass
    {
        private readonly HighSchoolContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<InsertClass> _logger;

        public InsertClass(HighSchoolContext context, IMapper mapper, ILogger<InsertClass> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<InsertClassResponse> Insert(ProcessorClassModel classModel)
        {
            try
            {
                var classEntity = _mapper.Map<Class>(classModel);
                await _context.Classes.AddAsync(classEntity);
                await _context.SaveChangesAsync();
                var response = new InsertClassResponse();
                response.Inserted = true;
                response.ClassModel = _mapper.Map<InsertClassModel>(classEntity);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error while inserting into Class : {@ex}", ex);
                throw new InsertClassInternalServerErrorException("Error while inserting the class in the db.");
            }
        }
    }
}
