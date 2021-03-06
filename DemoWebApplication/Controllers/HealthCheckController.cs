using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DemoWebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCheckController : ControllerBase
    {
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("HealthCheck Get...");
            return Ok("ok");
        }
    }
}