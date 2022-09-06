using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SwaggerTest.ClassLibrary1.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]")]
public class EchoController : ControllerBase
{
    private readonly ILogger<EchoController> _logger;

    public EchoController(ILogger<EchoController> logger)
    {
        _logger = logger;
    }

    [MapToApiVersion("1.0")]
    [HttpGet]
    public IActionResult Get(string value)
    {
        var response = new
                       {
                           Value = value
                       };

        return Ok(response);
    }
}
