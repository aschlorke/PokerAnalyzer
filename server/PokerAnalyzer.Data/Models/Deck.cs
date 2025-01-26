using PokerAnalyzer.Common;

namespace PokerAnalyzer.Data.Models;

public class Deck
{
    private List<Card> cards = new();
    Random rnd = new();
    public Deck()
    {
        ResetDeck();
    }

    public void ResetDeck(int? seed = null)
    {
        rnd = seed == null ? new Random() : new Random(seed.Value);
        cards.Clear();

        foreach (var suit in Enum.GetValues(typeof(Suit)).Cast<Suit>().ToList())
        {
            foreach (var valueRank in Constants.ValuesToRanks)
            {
                cards.Add(new() { Rank = valueRank.Value, Value = valueRank.Key, Suit = suit });
            }
        }

        ShuffleDeck();
    }

    public Card DrawCard()
    {

        if (cards.Count < 0)
        {
            throw new InvalidOperationException("Attempted to call DrawCard on an empty deck!");
        }
        var card = cards.First();
        cards.RemoveAt(0);
        return card;
    }

    public void ShuffleDeck()
    {
        cards = cards.OrderBy(c => rnd.Next()).ToList();
    }
}
