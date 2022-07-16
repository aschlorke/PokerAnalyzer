using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models.Rules
{
    public class PairRule : HandRule
    {
        public override string Name => "Pair";
        public override int Value => 2;
        public override bool HasHand(List<Card> cards) =>
            cards.GroupBy(c => c.Value).Count(g => g.Count() == 2) == 1;
        private List<Card> GetHand(List<Card> cards) =>
            cards.GroupBy(c => c.Value).Where(g => g.Count() == 2).First().ToList();

        public override TieBreakerResults TieBreaker(List<Card> cardsOne, List<Card> cardsTwo)
        {
            var firstPairValue = GetHand(cardsOne).Select(c => c.Value).First();
            var secondPairValue = GetHand(cardsTwo).Select(c => c.Value).First();

            if (firstPairValue > secondPairValue) return TieBreakerResults.FirstWins;
            else if (firstPairValue < secondPairValue) return TieBreakerResults.SecondWins;
            return TieBreakerResults.Tie;
        }

    }
}
