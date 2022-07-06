using CatalogFeatures.CreateClassUseCase;
using CatalogFeatures.CreateClassUseCase.BusinessLogic.ClassLogic;
using CatalogFeatures.CreateClassUseCase.BusinessLogic.StudentLogic;
using CatalogFeatures.CreateClassUseCase.Comands.InsertCatalogCommand;
using CatalogFeatures.CreateClassUseCase.Comands.InsertClassComand;
using CatalogFeatures.CreateClassUseCase.Comands.InsertStudentsCommand;
using CatalogFeatures.CreateClassUseCase.UseCaseResponseAndRequests;
using CatalogFeatures.DataRelatedToCatalogUseCase;
using CatalogFeatures.DataRelatedToCatalogUseCase.BusinessValidations;
using DapperORM;
using DapperORM.CatalogsRepository.CatalogRelatedDataUseCase;
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

            //Features
            CreateClassUseCase(services);
            GetCatalogDataUseCase(services);
        }

        private static void CreateClassUseCase(IServiceCollection services)
        {
            services.AddScoped<IRequestClassCatalogProcessor, UseCaseRequestProcessor>();
            services.AddScoped<IClassRequestProcessor, ClassRequestProcessor>();
            services.AddScoped<IRequestHandler, RequestHandler>();
            services.AddScoped<IInsertClass, InsertClass>();
            services.AddScoped<IInsertCatalog, InsertCatalog>();
            services.AddScoped<IStudentProcessor, StudentProcessor>();
            services.AddScoped<IInsertStudent, InsertStudent>();
            services.AddScoped<IResponseBuilder, ResponseBuilder>();
        }

        private static void GetCatalogDataUseCase(IServiceCollection services)
        {
            services.AddScoped<IGetDataFromCatalog, GetDataForCatalog>();
            services.AddScoped<IGetDataCatalogValidator, CatalogBusinessValidator>();
            services.AddScoped<ICatalogRelatedDataRepository, CatalogRelatedDataRepository>();
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
