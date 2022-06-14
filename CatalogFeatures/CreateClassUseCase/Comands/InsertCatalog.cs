using AutoMapper;
using EntityFrameworkORM.Models;

namespace CatalogFeatures.CreateClassUseCase.Comands
{
    public interface IInsertCatalog
    {
        Task<Catalog> Insert(Class classEntity);
    }
    public class InsertCatalog: IInsertCatalog
    {
        private readonly HighSchoolContext _context;
        private readonly IMapper _mapper;

        public InsertCatalog(HighSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Catalog> Insert(Class classEntity)
        {

            var catalog = new Catalog()
            {
                ClassId = classEntity.Id,
                ActiveCatalog = true,
                CurrentYear = classEntity.CurrentYear
            };
            await _context.Catalogs.AddAsync(catalog);
            await _context.SaveChangesAsync();
            return catalog;
        }
    }
}
