
namespace PokerAnalyzer.Data.Models;

public class Hand
{
    public List<Card> Cards { get; private set; }

    public Hand(List<Card> cards)
    {
        Cards = cards;
    }
}

