namespace PokerAnalyzer.Data.Models;

public class PokerGameResults
{
    public int PokerGameResultsId { get; init; }
    public int PokerGameId { get; init; }
    public required string Winner { get; init; }

    public required string WinningHand { get; init; }
}

