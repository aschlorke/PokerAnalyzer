using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models.Rules
{
    public class ThreeOfAKindRule : HandRule
    {
        public override string Name => "Three of a Kind";
        public override int Value => 4;
        public override bool HasHand(List<Card> cards) =>
            cards.GroupBy(c => c.Value).Any(g => g.Count() == 3);

        private List<Card> GetHand(List<Card> cards) =>
            cards.GroupBy(c => c.Value).Where(g => g.Count() == 3).First().ToList();

        public override TieBreakerResults TieBreaker(List<Card> cardsOne, List<Card> cardsTwo)
        {
            var firstTripValue = GetHand(cardsOne).Select(c => c.Value).First();
            var secondTripValue = GetHand(cardsTwo).Select(c => c.Value).First();

            if (firstTripValue > secondTripValue) return TieBreakerResults.FirstWins;
            else if (firstTripValue < secondTripValue) return TieBreakerResults.SecondWins;
            return TieBreakerResults.Tie;
        }
    }
}
