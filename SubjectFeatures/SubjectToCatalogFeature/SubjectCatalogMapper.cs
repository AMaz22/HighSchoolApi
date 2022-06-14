using AutoMapper;
using EntityFrameworkORM.Models;

namespace SubjectFeatures.SubjectToCatalogFeature
{
    public class SubjectCatalogMapper: Profile
    {
        public SubjectCatalogMapper()
        {
            CreateMap<SubjectCatalogModel, SubjectsCatalog>();
        }
    }
}
