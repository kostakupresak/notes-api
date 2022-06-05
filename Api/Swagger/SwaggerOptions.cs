using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Api.Swagger;

/// <summary>
/// Configure Swagger for API versioning.
/// </summary>
internal class ConfigureSwaggerOptions
    : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider provider;

    /// <summary>
    /// Constructor for <see cref="ConfigureSwaggerOptions"/>.
    /// </summary>
    /// <param name="provider">
    /// <see cref="IApiVersionDescriptionProvider"/>
    /// </param>
    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
    {
        this.provider = provider;
    }

    /// <summary>
    /// Configures <see cref="SwaggerGenOptions"/>.
    /// </summary>
    public void Configure(SwaggerGenOptions options)
    {
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(
                description.GroupName,
                CreateVersionInfo(description));
        }
    }

    /// <summary>
    /// Configures <see cref="SwaggerGenOptions"/> by the given name.
    /// </summary>
    /// <param name="name">Name.</param>
    /// <param name="options"><see cref="SwaggerGenOptions"/></param>
    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
    }

    private OpenApiInfo CreateVersionInfo(
            ApiVersionDescription description)
    {
        var info = new OpenApiInfo()
        {
            Title = "Notes API",
            Version = description.ApiVersion.ToString()
        };

        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }

        return info;
    }
}

