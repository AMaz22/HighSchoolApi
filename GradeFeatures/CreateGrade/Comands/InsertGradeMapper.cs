using AutoMapper;
using EntityFrameworkORM.Models;

namespace GradeFeatures.CreateGrade.Comands
{
    public class InsertGradeMapper : Profile
    {
        public InsertGradeMapper()
        {
            CreateMap<AddGradeModel, Grade>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.SubjectCatalogId, opt => opt.MapFrom(src => src.SubjectCatalogId))
                .ForMember(dest => dest.GradeScore, opt => opt.MapFrom(src => src.GradeScore));
            CreateMap<Grade, InsertedGradeModel>()
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.StudentId))
                .ForMember(dest => dest.SubjectCatalogId, opt => opt.MapFrom(src => src.SubjectCatalogId))
                .ForMember(dest => dest.GradeScore, opt => opt.MapFrom(src => src.GradeScore))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.GradeDate, opt => opt.MapFrom(src => src.GradeDate));
        }
    }
}
