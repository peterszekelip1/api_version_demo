using System.Reflection;
using Microsoft.AspNetCore.Mvc;

namespace SwaggerTest.WebApplication1;

public static class SwaggerHelper
{
    public static List<string> GetGroupNames()
    {
        var controllerTypes = AppDomain.CurrentDomain
                                       .GetAssemblies()
                                       .Where(assembly => !string.IsNullOrEmpty(assembly.FullName)
                                                       && assembly.FullName.StartsWith("SwaggerTest"))
                                       .SelectMany(assembly => assembly.GetTypes()
                                                                       .Where(type => type.IsDefined(typeof(ApiControllerAttribute))))
                                       .ToList();

        var groupNames = controllerTypes
                         .Select(type => type.GetCustomAttribute<ApiExplorerSettingsAttribute>())
                         .Where(attribute => attribute is not null)
                         .Select(attribute => attribute!.GroupName)
                         .Distinct()
                         .OrderBy(groupName => groupName)
                         .ToList();

        return groupNames!;
    }

    public static List<(string groupName, string title, string version)> GetGroupNameInformation()
    {
        var groupNames = GetGroupNames();

        var response = new List<(string groupName, string title, string version)>();
        foreach (var groupName in groupNames)
        {
            var (title, version) = ExtractInformationFromGroupName(groupName);
            response.Add((groupName, title, version));
        }
        return response;
    }

    private static (string title, string version) ExtractInformationFromGroupName(string groupName)
    {
        var values = groupName.Split('-');
        var name = values[0];
        var version = values[1][1..];
        var title = name.ToUpperInvariant();

        return (title, version);
    }
}
