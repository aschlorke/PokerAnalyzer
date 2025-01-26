
namespace PokerAnalyzer.Data.Models;

public class Card
{
    public int CardId { get; }
    public int PlayerId { get; init; }
    public required string Rank { get; init; }

    public required int Value { get; init; }

    public required Suit Suit { get; init; }
}
