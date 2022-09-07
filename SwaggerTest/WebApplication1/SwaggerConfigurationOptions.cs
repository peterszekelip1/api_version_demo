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
        foreach (var (groupName, title, version) in SwaggerHelper.GetGroupNameInformation())
        {
            var versionInfo = new OpenApiInfo
                              {
                                  Title = title,
                                  Version = version,
                              };

            options.SwaggerDoc(groupName, versionInfo);
        }

        // add swagger document for every API version discovered
        // foreach (var description in _apiVersionDescriptionProvider.ApiVersionDescriptions)
        // {
        //     options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
        // }
    }

    public void Configure(string name, SwaggerGenOptions options)
    {
        Configure(options);
    }
}
