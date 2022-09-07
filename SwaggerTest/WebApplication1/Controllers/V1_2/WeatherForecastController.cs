using Microsoft.AspNetCore.Mvc;

namespace SwaggerTest.WebApplication1.Controllers.V1_2;

[ApiController]
[ApiExplorerSettings(GroupName = "webapplication1-v1.2")]
[ApiVersion("1.2")]
[Route("api/v{version:apiVersion}/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [MapToApiVersion("1.2")]
    [HttpGet]
    public Response<WeatherForecast> Get()
    {
        var data = DataProvider.GetData(5);

        return new Response<WeatherForecast>(data, "1.1");
    }
}
