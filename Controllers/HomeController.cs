using Microsoft.AspNetCore.Mvc;
using Weather.Models;
using Weather.Controllers;

namespace Weather.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
    }
}
