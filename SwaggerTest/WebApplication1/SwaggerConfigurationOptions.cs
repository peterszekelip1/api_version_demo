using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SwaggerTest.WebApplication1;

public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
{
    private readonly IApiVersionDescriptionProvider _apiVersionDescriptionProvider;

    public ConfigureSwaggerOptions(IApiVersionDescriptionProvider apiVersionDescriptionProvider)
    {
        _apiVersionDescriptionProvider = apiVersionDescriptionProvider;
    }

    public void Configure(SwaggerGenOptions options)
    {
        // add swagger document for every API version discovered
        foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        }
    }

    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
    }

    private static OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
    {
        var info = new OpenApiInfo
                   {
                       Title = "Heroes API",
                       Version = description.ApiVersion.ToString()
                   };

        if (description.IsDeprecated)
        {
            info.Description += " This API version has been deprecated.";
        }

        return info;
    }
}
