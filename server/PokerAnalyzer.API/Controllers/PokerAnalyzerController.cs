using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PokerAnalyzer.Data.Models;

namespace PokerAnalyzer.API.Controllers;

[ApiController]
[Route ("[controller]")]
public class PokerAnalyzerController : ControllerBase
{
    private readonly ILogger<PokerAnalyzerController> _logger;
    private readonly IPokerAnalyzerService _service;

    public PokerAnalyzerController (ILogger<PokerAnalyzerController> logger, IPokerAnalyzerService pokerAnalyzerService)
    {
        _logger = logger;
        _service = pokerAnalyzerService;
    }

    [HttpGet (Name = "GetNewGame")]
    public IActionResult GetNewGame ()
    {
        var game = _service.GetNewGame ();
        return Ok (game);
    }
}
