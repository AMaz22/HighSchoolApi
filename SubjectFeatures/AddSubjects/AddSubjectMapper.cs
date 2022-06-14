using AutoMapper;
using EntityFrameworkORM.Models;

namespace SubjectFeatures.AddSubjects
{
    public class AddSubjectMapper : Profile
    {
        public AddSubjectMapper()
        {
            //  <Source -> Destination>
            CreateMap<SubjectModel, Subject>()
                .ForMember(destination => destination.SubjectName, opt => opt.MapFrom(src => src.SubjectName));
        }
    }
}
