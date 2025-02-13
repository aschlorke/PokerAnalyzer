using PokerAnalyzer.Data.Models;

namespace PokerAnalyzer.Services.Interfaces;

public interface IPokerPlayerService
{
    Task AddPlayer(Player player);
    Task<List<Player>> GetPlayers(CancellationToken cancellationToken = default);
    Task<List<Player>> GetPlayersByGameId(int gameId, CancellationToken cancellationToken = default);
    Task<Player> GetPlayerById(PlayerId playerId, CancellationToken cancellationToken = default);
    Task<bool> DeletePlayer(PlayerId playerId);
}