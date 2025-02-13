using Microsoft.AspNetCore.Mvc;
using PokerAnalyzer.API.Requests;
using PokerAnalyzer.Data.Models;
using PokerAnalyzer.Services.Interfaces;

namespace PokerAnalyzer.API.Controllers;

[ApiController]
[Route("poker-players")]
public class PokerPlayerController : ControllerBase
{
    private readonly IPokerPlayerService _service;

    public PokerPlayerController(IPokerPlayerService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult> AddPlayer([FromBody] AddPlayerRequest request)
    {
        await _service.AddPlayer(Player.Create(request.Name));
        return Ok();
    }

    [HttpGet]
    public async Task<List<Player>> GetPlayers()
    {
        var players = await _service.GetPlayers();
        return players;
    }
    [HttpGet("{playerId}")]
    public async Task<Player> GetPlayerById(Guid playerId)
    {
        var player = await _service.GetPlayerById(new(playerId));
        return player;
    }
    [HttpGet("games/{gameId}")]
    public async Task<List<Player>> GetPlayersByGameId(int gameId)
    {
        var players = await _service.GetPlayersByGameId(gameId);
        return players;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePlayer(Guid id)
    {
        bool found = await _service.DeletePlayer(new(id));
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
