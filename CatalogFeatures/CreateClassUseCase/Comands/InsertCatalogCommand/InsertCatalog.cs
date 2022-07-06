using AutoMapper;
using CatalogFeatures.CreateClassUseCase.Comands.InsertClassComand;
using EntityFrameworkORM.Models;

namespace CatalogFeatures.CreateClassUseCase.Comands.InsertCatalogCommand
{
    public interface IInsertCatalog
    {
        Task<InsertCatalogResponse> Insert(InsertClassResponse classEntity);
    }
    public class InsertCatalog : IInsertCatalog
    {
        private readonly HighSchoolContext _context;
        private readonly IMapper _mapper;

        public InsertCatalog(HighSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<InsertCatalogResponse> Insert(InsertClassResponse insertclassReponse)
        {
            var response = new InsertCatalogResponse();
            try
            {
                var catalogEntity = _mapper.Map<Catalog>(insertclassReponse.ClassModel);
                catalogEntity.ActiveCatalog = true;
                await _context.Catalogs.AddAsync(catalogEntity);
                await _context.SaveChangesAsync();
                response.CatalogModel = _mapper.Map<InsertCatalogModel>(catalogEntity);
                response.Inseted = true;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.Message;
                response.Inseted = false;
            }
            return response;
        }
    }
}
