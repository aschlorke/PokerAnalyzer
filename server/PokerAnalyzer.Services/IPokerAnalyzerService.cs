using PokerAnalyzer.Data.Models;

public interface IPokerAnalyzerService
{
    PokerGame GetNewGame();
    PokerGame GetExistingGameById(int id);
    bool DeleteGameById(int id);
}