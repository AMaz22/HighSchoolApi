using AutoMapper;
using CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic;
using CatalogFeatures.CreateClassUseCase.Comands.InsertClassComand;
using EntityFrameworkORM.Models;

namespace CatalogFeatures.CreateClassUseCase.Comands.InsertCatalogCommand
{
    public class InsertCommandsMapper : Profile
    {
        public InsertCommandsMapper()
        {
            CreateMap<InsertClassModel, Catalog>()
                .ForMember(dest => dest.CurrentYear, opt => opt.MapFrom(src => src.ClassYear))
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId));

            CreateMap<Catalog, InsertCatalogModel>()
                .ForMember(dest => dest.CatalogId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CurrentYear, opt => opt.MapFrom(src => src.CurrentYear))
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.ClassId));
        }     
    }
}
