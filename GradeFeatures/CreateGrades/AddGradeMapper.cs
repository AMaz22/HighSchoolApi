using AutoMapper;
using EntityFrameworkORM.Models;

namespace GradeFeatures.CreateGrades
{
    public class AddGradeMapper : Profile
    {
        public AddGradeMapper()
        {
            CreateMap<Grade, AddGradeModel>();
        }
    }
}
