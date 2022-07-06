using AutoMapper;
using CatalogFeatures.CreateClassUseCase.BusinessLogic.StudentLogic;
using EntityFrameworkORM.Models;

namespace CatalogFeatures.CreateClassUseCase.Comands.InsertStudentsCommand
{
    public class InsertStudentMapper : Profile
    {
        public InsertStudentMapper()
        {
            CreateMap<InsertStudentModel, Student>()
                .ForMember(dest => dest.CatalogId, opt => opt.MapFrom(src => src.CatalogId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StudentYear, opt => opt.MapFrom(src => src.StudentCurrentYear));
            
            CreateMap<Student, InsertStudentModel>()
                .ForMember(dest => dest.CatalogId, opt => opt.MapFrom(src => src.CatalogId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.StudentCurrentYear, opt => opt.MapFrom(src => src.StudentYear))
                .ForMember(dest => dest.StudentId, opt => opt.MapFrom(src => src.Id));

            CreateMap<StudentProcessorResponse, Student>()
                .ForMember(dest => dest.CatalogId, opt => opt.MapFrom(src => src.CatalogId))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.StudentYear, opt => opt.MapFrom(src => src.StudentYear));
        }
    }
}
