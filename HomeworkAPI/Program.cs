using CatalogFeatures.Setup;
using HomeworkAPI.Middleware;
using StudentFeature.Setup;
using SubjectFeatures.Setup;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSubjectFeature(builder.Configuration);

builder.Services.AddCatalogFeatures(builder.Configuration.GetConnectionString("DbConnection"));

builder.Services.AddStudentFeatures(builder.Configuration);


builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

//Exception handler middleware
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();

app.Run();
