using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models.Rules
{
    public class FourOfAKindRule : HandRule
    {
        public override string Name => "Four of a Kind";
        public override int Value => 7;

        public override bool HasHand(List<Card> cards) =>
            cards.GroupBy(c => c.Value).Any(g => g.Count() == 4);

        private List<Card> GetHand(List<Card> cards) =>
            cards.GroupBy(c => c.Value).Where(g => g.Count() == 4).First().ToList();

        public override TieBreakerResults TieBreaker(List<Card> cardsOne, List<Card> cardsTwo)
        {
            var firstQuadValue = GetHand(cardsOne).Select(c => c.Value).First();
            var secondQuadValue = GetHand(cardsTwo).Select(c => c.Value).First();

            if (firstQuadValue > secondQuadValue) return TieBreakerResults.FirstWins;
            else if (firstQuadValue < secondQuadValue) return TieBreakerResults.SecondWins;
            return TieBreakerResults.Tie;
        }

    }
}
