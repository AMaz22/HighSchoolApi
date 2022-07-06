using AutoMapper;
using EntityFrameworkORM.Models;

namespace CatalogFeatures.CreateClassUseCase.Comands.InsertClassComand
{
    public class InsertClassMapper : Profile
    {
        public InsertClassMapper()
        {
            CreateMap<Class, InsertClassModel>()
                .ForMember(dest => dest.ClassId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ClassCicle, opt => opt.MapFrom(src => src.ClassCicle))
                .ForMember(dest => dest.ClassYear, opt => opt.MapFrom(src => src.CurrentYear));
        }
    }
}
