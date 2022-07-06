using AutoMapper;
using CatalogFeatures.CreateClassUseCase.UseCaseResponseAndRequests;

namespace CatalogFeatures.CreateClassUseCase.BusinessLogic.StudentLogic
{
    public class StudentRequestResponseMapper: Profile
    {
        public StudentRequestResponseMapper()
        {
            CreateMap<StudentApiRequest, StudentProcessorResponse>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
