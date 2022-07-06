using EntityFrameworkORM.Models;
using FluentValidation.AspNetCore;
using GradeFeatures.CreateGrade;
using GradeFeatures.CreateGrade.BusinessLogic.BusinessValidations;
using GradeFeatures.CreateGrade.Comands;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GradeFeatures.Setup
{
    public static class Startup
    {
        public static void AddGradeFeatures(this IServiceCollection services, string efConnection)
        {
            NuggetsSettings(services);

            SetEntityFrameworkContext(services, efConnection);
            
            CreateGradeUseCase(services);
        }

        private static void CreateGradeUseCase(IServiceCollection services)
        {
            services.AddScoped<IAssignGrade, AssignGrade>();
            services.AddScoped<IStudentValidator, StudentValidator>();
            services.AddScoped<ISubjectCatalogValidator, SubjectCatalogValidator>();
            services.AddScoped<IInsertGrade, InsertGrade>();
        }

        private static void SetEntityFrameworkContext(IServiceCollection services, string efConnection)
        {
            services.AddDbContext<HighSchoolContext>(option =>
                option.UseSqlServer(efConnection));
        }

        private static void NuggetsSettings(IServiceCollection services)
        {
            services.AddFluentValidation(options =>
            {
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}