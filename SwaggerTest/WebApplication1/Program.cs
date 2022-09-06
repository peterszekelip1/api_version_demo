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

builder.Services.AddSwaggerGen(options =>
                               {
                                   // note: need a temporary service provider here because one has not been created yet
                                   // var provider = builder
                                   //                .Services
                                   //                .BuildServiceProvider()
                                   //                .GetRequiredService<IApiVersionDescriptionProvider>();

                                   // add a swagger document for each discovered API version
                                   // foreach ( var description in provider.ApiVersionDescriptions )
                                   // {
                                   //     options.SwaggerDoc( description.GroupName, CreateInfoForApiVersion( description ) );
                                   // }
                               });
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
                         foreach (var desc in apiVersionDescriptionProvider.ApiVersionDescriptions)
                         {
                             options.SwaggerEndpoint($"/swagger/{desc.GroupName}/swagger.json", desc.ApiVersion.ToString());
                             options.DefaultModelsExpandDepth(-1);
                             options.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
                         }
                     });
}

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
