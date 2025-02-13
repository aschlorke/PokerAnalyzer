namespace PokerAnalyzer.Data.Models;

public class PokerHand
{
    public required PlayerId PlayerId { get; init; }
    public required List<Card> Cards { get; init; }
}
