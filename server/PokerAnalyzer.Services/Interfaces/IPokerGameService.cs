using PokerAnalyzer.Data.Models;

namespace PokerAnalyzer.Services.Interfaces;

public interface IPokerGameService
{
    Task<PokerGameWithResults?> CreateGame(int numberOfPlayers);
    Task<PokerGameWithResults?> CreateGame(List<PlayerId> playerIds);
    Task<PokerGameWithResults> GetExistingGameById(int id);
    Task<List<PokerGameWithResults>> GetExistingGames();
    Task<List<int>> GetExistingGameIds();
    Task<bool> DeleteGameById(int id);
}