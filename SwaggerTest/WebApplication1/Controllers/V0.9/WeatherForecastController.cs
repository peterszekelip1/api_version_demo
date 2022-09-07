using Microsoft.AspNetCore.Mvc;

namespace SwaggerTest.WebApplication1.Controllers.V0_9;

[ApiController]
[ApiExplorerSettings(GroupName = "webapplication1-v0.9")]
[ApiVersion("0.9", Deprecated = true)]
[Route("api/v{version:apiVersion}/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [MapToApiVersion("0.9")]
    [HttpGet]
    public Response<WeatherForecast> Get()
    {
        var data = DataProvider.GetData(5);

        return new Response<WeatherForecast>(data, "0.9");
    }
}
