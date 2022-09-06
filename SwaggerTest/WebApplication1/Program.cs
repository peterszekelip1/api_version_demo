using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using SwaggerTest.WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApiVersioning(options =>
                                  {
                                      options.DefaultApiVersion = new ApiVersion(1, 0);
                                      options.AssumeDefaultVersionWhenUnspecified = true;
                                      options.ReportApiVersions = true;
                                  });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddVersionedApiExplorer(options =>
                                         {
                                             options.GroupNameFormat = "'v'VVV";
                                             options.SubstituteApiVersionInUrl = true;
                                         });

builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();

var app = builder.Build();

var apiVersionDescriptionProvider = builder
               .Services
               .BuildServiceProvider()
               .GetRequiredService<IApiVersionDescriptionProvider>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
                     {
                         options.SwaggerEndpoint("/swagger/webapplication1-v1/swagger.json", "WebApplication1 v1");
                         options.SwaggerEndpoint("/swagger/webapplication1-v2/swagger.json", "WebApplication1 v2");
                         options.SwaggerEndpoint("/swagger/classlibrary1-v1/swagger.json", "ClassLibrary v1");
                         // foreach (var desc in apiVersionDescriptionProvider.ApiVersionDescriptions)
                         // {
                         //     options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", desc.ApiVersion.ToString());
                         //     options.DefaultModelsExpandDepth(-1);
                         //     options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                         // }
                     });
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
