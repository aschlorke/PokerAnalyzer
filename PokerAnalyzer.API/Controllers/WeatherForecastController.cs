using Microsoft.AspNetCore.Mvc;

namespace PokerAnalyzer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PokerAnalyzerController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<PokerAnalyzerController> _logger;

    public PokerAnalyzerController(ILogger<PokerAnalyzerController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "CreateNewGame")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}
