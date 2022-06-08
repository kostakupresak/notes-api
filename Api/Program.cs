using Api.Swagger;
using BusinessLogic;
using Contracts.Repositories;
using Contracts.Services;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

var builder = WebApplication.CreateBuilder(args);

// Adding API versioning and documentation.
builder.Services.AddApiVersioning(setupAction =>
{
    setupAction.AssumeDefaultVersionWhenUnspecified = true;
    setupAction.DefaultApiVersion = new ApiVersion(1, 0);
    setupAction.ReportApiVersions = true;
});
builder.Services.AddVersionedApiExplorer(setupAction =>
{
    setupAction.GroupNameFormat = "'v'VVV";
    setupAction.SubstituteApiVersionInUrl = true;
});
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

builder.Services.AddControllers();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<INoteRepository, NoteRepository>();

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<INoteService, NoteService>();

var app = builder.Build();
var provider = app.Services
    .GetRequiredService<IApiVersionDescriptionProvider>();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    foreach (var apiVersionDescription in provider.ApiVersionDescriptions)
    {
        options.SwaggerEndpoint(
            $"/swagger/{apiVersionDescription.GroupName}/swagger.json",
            apiVersionDescription.GroupName.ToUpperInvariant());
    }
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

