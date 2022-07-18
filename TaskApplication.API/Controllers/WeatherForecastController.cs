using Microsoft.AspNetCore.Mvc;

namespace TaskApplication.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Hello, World!";
        }

        [HttpGet("Number")]
        public int GetNumber()
        {
            return GetNumber(0);
        }

        [HttpGet("Number/{id}")]
        public int GetNumber(int id)
        {
            if(id == 0)
            {
                var rng = new Random();
                return rng.Next();
            }
            return id;
        }
    }
}