using CatalogFeatures.Setup;
using GradeFeatures.Setup;
using HomeworkAPI.Middleware;
using Serilog;
using StudentFeature.Setup;
using SubjectFeatures.Setup;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    EnvironmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")
});

var logger = new LoggerConfiguration()
        .ReadFrom.Configuration(builder.Configuration)
        .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSubjectFeature(builder.Configuration);
builder.Services.AddCatalogFeatures(builder.Configuration.GetConnectionString("DbConnection"));
builder.Services.AddStudentFeatures(builder.Configuration);
builder.Services.AddGradeFeatures(builder.Configuration.GetConnectionString("DbConnection"));


builder.Services.AddAuthentication("Bearer")
    .AddIdentityServerAuthentication("Bearer", options =>
    {
        options.ApiName = "myApi";
        options.Authority = "https://localhost:7086";

    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//Exception handler middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
