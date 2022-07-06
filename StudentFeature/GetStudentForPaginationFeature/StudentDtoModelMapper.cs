using AutoMapper;
using DapperORM.StudentRepository.GetStudentsForGridRepository;

namespace StudentFeature.GetStudentForPaginationFeature
{
    public class StudentDtoModelMapper : Profile
    {
        public StudentDtoModelMapper()
        {
            CreateMap<StudentDetails, StudentUIDetails>()
                .ForMember(dest => dest.StudentYear, opt => opt.MapFrom(src => src.StudentYear))
                .ForMember(dest => dest.StudentName, opt => opt.MapFrom(src => src.StudentName))
                .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.ID))
                .ForMember(dest => dest.CatalogID, opt => opt.MapFrom(src => src.CatalogID));
            CreateMap<StudentsDto, StudentGridModel>()
                   .ForMember(dest => dest.StudentUIDetails, opt => opt.MapFrom(src => src.StudentDetails));
        }
    }
}
