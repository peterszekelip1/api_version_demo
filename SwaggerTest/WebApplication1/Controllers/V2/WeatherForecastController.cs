using Microsoft.AspNetCore.Mvc;

namespace SwaggerTest.WebApplication1.Controllers.V2;

[ApiController]
[ApiExplorerSettings(GroupName = "webapplication1-v2")]
[ApiVersion("2.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [MapToApiVersion("2.0")]
    [HttpGet]
    public Response<WeatherForecast> Get()
    {
        var data = DataProvider.GetData(5);

        return new Response<WeatherForecast>(data, "2.0");
    }
}
