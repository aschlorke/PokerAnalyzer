using PokerAnalyzer.Data.Models;

namespace PokerAnalyzer.Services;

public interface IPokerAnalyzerService
{
    Task<PokerGame?> CreateGame(int numberOfPlayers);
    Task<PokerGame> GetExistingGameById(int id);
    Task<List<PokerGame>> GetExistingGames();
    Task<List<int>> GetExistingGameIds();
    Task<bool> DeleteGameById(int id);
}