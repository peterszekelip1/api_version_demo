namespace SwaggerTest.WebApplication1;

public static class WebApplicationExtensions
{
    public static void ConfigureSwagger(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(options =>
                         {
                             foreach (var groupName in SwaggerHelper.GetGroupNames())
                             {
                                 options.SwaggerEndpoint($"/swagger/{groupName}/swagger.json", groupName);
                             }
                         });
    }
}
