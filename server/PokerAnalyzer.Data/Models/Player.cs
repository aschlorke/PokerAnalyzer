
namespace PokerAnalyzer.Data.Models;
public class Player
{
    public int PlayerId { get; }
    public int PokerGameId { get; init; }
    public required string Name { get; init; }

    public required List<Card> Cards { get; init; }
}
