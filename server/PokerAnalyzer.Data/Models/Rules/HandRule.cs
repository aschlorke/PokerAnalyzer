using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models.Rules
{
    public abstract class HandRule
    {
        public abstract string Name { get; }
        public abstract int Value { get; }
        public abstract bool HasHand(List<Card> cards);
        public abstract TieBreakerResults TieBreaker(List<Card> cardsOne, List<Card> cardsTwo);
    }
}
