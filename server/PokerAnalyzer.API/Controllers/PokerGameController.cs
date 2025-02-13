using Microsoft.AspNetCore.Mvc;
using PokerAnalyzer.API.Requests;
using PokerAnalyzer.Data.Models;
using PokerAnalyzer.Services.Interfaces;

namespace PokerAnalyzer.API.Controllers;

[ApiController]
[Route("poker-games")]
public class PokerGameController : ControllerBase
{
    private readonly IPokerGameService _service;

    public PokerGameController(IPokerGameService service)
    {
        _service = service;
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [HttpPost]
    public async Task<ActionResult<PokerGameWithResults>> GetNewGame([FromBody] NewGameRequest request)
    {
        if (request.NumberOfPlayers < 1 || request.NumberOfPlayers > 10)
        {
            return BadRequest("Number of players must be greater than 1 and less than 10");
        }
        var game = await _service.CreateGame(request.NumberOfPlayers);
        if (game != null)
        {
            return Ok(game);
        }
        return StatusCode(StatusCodes.Status500InternalServerError, "Game was unable to be created");
    }

    [HttpPost("with-players")]
    public async Task<ActionResult<PokerGameWithResults>> CreateGame([FromBody] NewGameWithPlayerIdsRequest request)
    {
        var game = await _service.CreateGame(request.PlayerIds);
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
    public async Task<ActionResult<PokerGameWithResults>> GetExistingGame(int id)
    {
        if (id < 0) return BadRequest("Id of game must be greater than or equal to 0");

        PokerGame game;
        try
        {
            game = await _service.GetExistingGameById(id);
        }
        catch (KeyNotFoundException)
        {
            return NotFound($"Game with id {id} was not found");
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
        return Ok(game);
    }

    [HttpGet]
    public async Task<ActionResult<List<PokerGameWithResults>>> GetExistingGames()
    {
        var games = await _service.GetExistingGames();
        return games;
    }


    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [HttpGet("GetExistingIds")]
    public async Task<ActionResult<List<int>>> GetExistingIds()
    {
        var ids = await _service.GetExistingGameIds();
        if (!ids.Any())
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }
        ids.Sort();
        return Ok(ids);
    }

    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGame(int id)
    {
        if (id < 0) return BadRequest("Id of game must be greater than 0");

        bool found = await _service.DeleteGameById(id);
        if (found)
        {
            return Ok(found);
        }
        else
        {
            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
