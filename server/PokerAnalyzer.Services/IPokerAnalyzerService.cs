using PokerAnalyzer.Data.Models;

public interface IPokerAnalyzerService
{
    PokerGame? CreateGame(int numberOfPlayers);
    PokerGame GetExistingGameById(int id);
    List<PokerGame> GetExistingGames();
    List<int> GetExistingGameIds();
    bool DeleteGameById(int id);
}