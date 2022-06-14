using AutoMapper;
using DapperORM.SubjectsRepository.Dtos;

namespace SubjectFeatures.GetSubjects
{
    public class SubjectDtoMapper: Profile
    {
        public SubjectDtoMapper()
        {
            CreateMap<SubjectByIdDto, GetSubjectDto>();
            
        }
    }
}
