using Microsoft.AspNetCore.Mvc;

namespace SwaggerTest.WebApplication1.Controllers.V1;

[ApiController]
[ApiExplorerSettings(GroupName = "webapplication1-v1")]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class CurrentTimeController : ControllerBase
{
    private readonly ILogger<CurrentTimeController> _logger;

    public CurrentTimeController(ILogger<CurrentTimeController> logger)
    {
        _logger = logger;
    }

    [MapToApiVersion("1.0")]
    [HttpGet("utc-now")]
    public IActionResult GetUtcNow()
    {
        return Ok(DateTime.UtcNow);
    }
}
