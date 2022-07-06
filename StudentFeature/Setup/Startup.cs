using DapperORM;
using DapperORM.StudentRepository.GetStudentsForGridRepository;
using EntityFrameworkORM.Models;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentFeature.CreateStudent;
using StudentFeature.GetStudentForPaginationFeature;
using System.Reflection;

namespace StudentFeature.Setup
{
    public static class Startup
    {
        public static void AddStudentFeatures(this IServiceCollection services, IConfiguration configuration)
        {
            AddEntityFramework(services, configuration);

            ConfigureNuggets(services);

            AddCreateStudentFeatures(services);

            GetSudentForGridFeature(services);
        }
        private static void GetSudentForGridFeature(IServiceCollection services)
        {
            services.AddScoped<IGetStudentsForGridRepository, GetStudentsForGridRepository>();

            services.AddScoped<IGetStudentsForGrid, GetStudentsForGrid>();
        }

        private static void AddEntityFramework(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HighSchoolContext>(option => 
                option.UseSqlServer(configuration.GetConnectionString("DbConnection")));
            
            services.AddScoped<IDapperRepository, DapperRepository>();
        }

        private static void AddCreateStudentFeatures(IServiceCollection services)
        {
            services.AddScoped<IStudentCreateFeature, StudentCreateFeature>();
        }

        private static void ConfigureNuggets(IServiceCollection services)
        {
            services.AddFluentValidation(options =>
            {
                options.ImplicitlyValidateChildProperties = true;
                options.ImplicitlyValidateRootCollectionElements = true;
                options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                
            });
            //services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
