using AutoMapper;
using CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic;
using EntityFrameworkORM.Models;

namespace CatalogFeatures.CreateClassUseCase.Comands
{
    public class InsertCommandsMapper: Profile
    {
        public InsertCommandsMapper()
        {
            CreateMap<ResponseClassModel, Class>();
            
            CreateMap<Class, Catalog>()
                .ForMember(dest => dest.CurrentYear, opt => opt.MapFrom(src => src.CurrentYear))
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.Id));
        }
    }
}
