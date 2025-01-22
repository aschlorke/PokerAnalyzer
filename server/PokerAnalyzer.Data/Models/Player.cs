
namespace PokerAnalyzer.Data.Models;
public class Player
{
    public required string Name { get; init; }
    
    public required List<Card> Cards { get; init; }
}
