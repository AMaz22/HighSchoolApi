using AutoMapper;

namespace CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic
{
    public class ClassModelMapper : Profile
    {
        public ClassModelMapper()
        {
            CreateMap<RequestClassModel, ResponseClassModel>();
        }
    }
}
