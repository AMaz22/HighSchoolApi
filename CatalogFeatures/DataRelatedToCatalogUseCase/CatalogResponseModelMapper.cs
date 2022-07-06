using AutoMapper;
using DapperORM.CatalogsRepository.CatalogRelatedDataUseCase;

namespace CatalogFeatures.DataRelatedToCatalogUseCase
{
    public class CatalogResponseModelMapper : Profile
    {
        public CatalogResponseModelMapper()
        {
            CreateMap<CatalogDetails, DataRelatedToCatalogDetails>()
                .ForMember(dest => dest.GradeScore, opt => opt.MapFrom(src => src.GradeScore))
                .ForMember(dest => dest.SubjectName, opt => opt.MapFrom(src => src.SubjectName))
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.StudentName))
                .ForMember(dest => dest.ClassCicle, opt => opt.MapFrom(src => src.ClassCicle))
                .ForMember(dest => dest.StudentID, opt => opt.MapFrom(src => src.StudentID))
                .ForMember(dest => dest.NameOfClass, opt => opt.MapFrom(src => src.NameOfClass));
        }
    }
}
