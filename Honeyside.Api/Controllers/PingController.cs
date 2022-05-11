using Microsoft.AspNetCore.Mvc;

namespace Honeyside.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    private readonly ILogger<PingController> _logger;

    public PingController(ILogger<PingController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogDebug("Someone pinged the API");

        return new OkResult();
    }
}
