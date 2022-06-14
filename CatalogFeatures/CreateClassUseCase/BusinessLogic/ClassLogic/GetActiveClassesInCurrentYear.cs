using DapperORM.CatalogsRepository.ClassJoinCatalogUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic
{
    public class GetActiveClassesInCurrentYear
    {
        private readonly ClassJoinCatalogRepository _repository;
        public GetActiveClassesInCurrentYear(ClassJoinCatalogRepository repository)
        {
            _repository = repository;
        }

    }
}
