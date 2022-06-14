using DapperORM;
using DapperORM.SubjectsRepository;
using EntityFrameworkORM.Models;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SubjectFeatures.AddSubjects;
using SubjectFeatures.GetSubjects;
using SubjectFeatures.SubjectToCatalogFeature;
using System.Reflection;

namespace SubjectFeatures.Setup
{
    public static class StartupSubjects
    {
        public static void AddSubjectFeature(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure database
            AddEntityFrameworkContext(services, configuration);

            // Configure nuget
            AddNugets(services);

            // Configure custom services
            AddSubjectServices(services);

            AddSubjectCatalogServices(services);
        }

        private static void AddSubjectServices(IServiceCollection services)
        {
            services.AddScoped<IAddSubject, AddSubject>();
            services.AddScoped<ISubjectRepository, GetSubjectRepository>();
            services.AddScoped<IGetSubject, GetSubject>();
        }

        private static void AddSubjectCatalogServices(IServiceCollection services)
        {
            services.AddScoped<IAssignSubjectToCatalog, AssignSubjectToCatalog>();
        }

        private static void AddEntityFrameworkContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HighSchoolContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DbConnection"))
            );
            services.AddScoped<IDapperRepository, DapperRepository>();
        }
        private static void AddNugets(IServiceCollection services)
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
