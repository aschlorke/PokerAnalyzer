namespace PokerAnalyzer.Data.Models;

public class PokerGame
{
    public required int Id { get; init; }

    public required List<Player> Players { get; init; }

    public required PokerGameResults Results { get; init; }
}

