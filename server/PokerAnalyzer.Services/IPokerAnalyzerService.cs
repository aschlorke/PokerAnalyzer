using PokerAnalyzer.Data.Models;

public interface IPokerAnalyzerService
{
    PokerGame? GetNewGame(int numberOfPlayers);
    PokerGame GetExistingGameById(int id);
    bool DeleteGameById(int id);
}