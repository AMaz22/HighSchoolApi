using AutoMapper;
using CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic;
using EntityFrameworkORM.Models;

namespace CatalogFeatures.CreateClassUseCase.Comands
{
    public interface IInsertClass
    {
        Task<Class> Insert(ResponseClassModel classModel);
    }

    public class InsertClass: IInsertClass
    {
        private readonly HighSchoolContext _context;
        private readonly IMapper _mapper;
        public InsertClass(HighSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Class> Insert(ResponseClassModel classModel)
        {
            var classEntity = _mapper.Map<Class>(classModel);

            await _context.Classes.AddAsync(classEntity);

            await _context.SaveChangesAsync();

            return classEntity;
        }
    }
}
