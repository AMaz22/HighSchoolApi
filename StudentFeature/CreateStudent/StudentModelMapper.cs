using AutoMapper;
using EntityFrameworkORM.Models;
using StudentFeature.CreateStudent;

namespace StudentFeature.CreateStudent
{
    public class StudentModelMapper : Profile
    {
        public StudentModelMapper()
        {
            CreateMap<StudentModel, Student>();
        }
    }
}
