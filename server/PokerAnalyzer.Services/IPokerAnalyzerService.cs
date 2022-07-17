using PokerAnalyzer.Data.Models;

public interface IPokerAnalyzerService
{
    PokerGame? GetNewGame (int numberOfPlayers);
    PokerGame GetExistingGameById (int id);
    List<int> GetExistingGameIds ();
    bool DeleteGameById (int id);
}