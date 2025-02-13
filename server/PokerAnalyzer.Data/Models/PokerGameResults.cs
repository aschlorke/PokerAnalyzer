namespace PokerAnalyzer.Data.Models;

public class PokerGameResults
{
    public required PlayerId Winner { get; init; }

    public required string WinningHand { get; init; }
}

