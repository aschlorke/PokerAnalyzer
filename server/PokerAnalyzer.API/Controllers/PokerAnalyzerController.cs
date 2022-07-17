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
    [HttpPost, Route("GetNewGame")]
    public ActionResult<PokerGame> GetNewGame([FromBody] int numberOfPlayers)
    {
        if (numberOfPlayers < 1 || numberOfPlayers > 10)
        {
            return BadRequest("Number of players must be greater than 1 and less than 10");
        }
        var game = _service.GetNewGame(numberOfPlayers);
        if (game != null)
        {
            return Ok(game);
        }
        return StatusCode(StatusCodes.Status500InternalServerError, "Game was unable to be created");
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpGet("{id}")]
    public ActionResult<PokerGame> GetExistingGame(int id)
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

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    public IActionResult DeleteGame(int id)
    {
        if (id < 0) return BadRequest("Id of game must be greater than 0");

        bool success = _service.DeleteGameById(id);
        if (success)
        {
            return Ok($"Successfully deleted game with id: {id}");
        }
        else
        {
            return StatusCode(StatusCodes.Status204NoContent, $"Game not found with id: {id}");
        }
    }
}
