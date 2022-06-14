using EntityFrameworkORM.Models;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CatalogClassesFeatures.Setup
{
    public static class Startup
    {
        public static void AddGradeFeatures(this IServiceCollection services, IConfiguration configuration)
        {
            AddServices(services);

            SetEntityFrameworkContext(services, configuration);

            NuggetsSettings(services);
        }

        private static void AddServices(IServiceCollection services)
        {
            
        }

        private static void SetEntityFrameworkContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<HighSchoolContext>(option =>
                option.UseSqlServer(configuration.GetConnectionString("DbConnection")));
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