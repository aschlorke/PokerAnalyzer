using Microsoft.AspNetCore.Mvc;
using PokerAnalyzer.Data.Models;

namespace PokerAnalyzer.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PokerAnalyzerController : ControllerBase
{
    private readonly ILogger<PokerAnalyzerController> _logger;
    private readonly IPokerAnalyzerService _service;

    public PokerAnalyzerController(ILogger<PokerAnalyzerController> logger, IPokerAnalyzerService pokerAnalyzerService)
    {
        _logger = logger;
        _service = pokerAnalyzerService;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpGet(Name = "GetNewGame")]
    public IActionResult GetNewGame()
    {
        var game = _service.GetNewGame();
        return Ok(game);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [Route("/{id}")]
    [HttpGet(Name = "GetExistingGame")]
    public IActionResult GetExistingGame(int id)
    {
        if (id < 0) return BadRequest("Id of game must be greater than 0");

        PokerGame game;
        try
        {
            game = _service.GetExistingGameById(id);
        }
        catch (KeyNotFoundException _)
        {
            return NotFound($"Game with id {id} was not found");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
        return Ok(game);
    }

}
