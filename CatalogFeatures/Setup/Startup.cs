using CatalogFeatures.CreateClassUseCase;
using CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic;
using CatalogFeatures.CreateClassUseCase.Comands;
using DapperORM;
using EntityFrameworkORM.Models;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CatalogFeatures.Setup
{
    public static class Startup
    {
        public static void AddCatalogFeatures(this IServiceCollection services, string dbConnection)
        {
            AddDbConnections(services, dbConnection);

            ConfigureNuggets(services);

            CreateClassUseCase(services);
        }

        private static void CreateClassUseCase(IServiceCollection services)
        {
            services.AddScoped<IRequestClassCatalogProcessor, RequestClassCatalogProcessor>();

            services.AddScoped<IClassRequestProcessor, ClassRequestProcessor>();
            services.AddScoped<IRequestClassValidator, RequestClassValidator>();
            services.AddScoped<IInsertClass, InsertClass>();
            services.AddScoped<IInsertCatalog, InsertCatalog>();
        }



        private static void AddDbConnections(IServiceCollection services, string dbConnection)
        {
            services.AddDbContext<HighSchoolContext>(option =>
                option.UseSqlServer(dbConnection));

            services.AddScoped<IDapperRepository, DapperRepository>();
        }
        private static void ConfigureNuggets(IServiceCollection services)
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
