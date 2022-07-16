using PokerAnalyzer.Common;

namespace PokerAnalyzer.Data.Models
{
    public class Deck
    {
        private List<Card> cards = new();
        public Deck()
        {
            ResetDeck();
        }

        public void ResetDeck()
        {
            cards.Clear();

            foreach (var suit in Enum.GetValues(typeof(Suit)).Cast<Suit>().ToList())
            {
                foreach (var valueRank in Constants.ValuesToRanks)
                {
                    cards.Add(new(valueRank.Value, valueRank.Key, suit));
                }
            }

            ShuffleDeck();
        }

        public Card DrawCard()
        {

            if (cards.Count < 0)
            {
                // TODO: Throw an error, this should never happen in this example app though
            }
            var card = cards.First();
            cards.RemoveAt(0);
            return card;
        }

        public void ShuffleDeck()
        {
            Random rnd = new();
            cards = cards.OrderBy(c => rnd.Next()).ToList();
        }
    }
}
