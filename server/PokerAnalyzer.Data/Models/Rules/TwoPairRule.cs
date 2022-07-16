using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models.Rules
{
    public class TwoPairRule : HandRule
    {
        public override string Name => "Two Pair";
        public override int Value => 3;
        public override bool HasHand(List<Card> cards) =>
            cards.GroupBy(c => c.Value).Count(g => g.Count() == 2) == 2;

        private List<int> GetHandValues(List<Card> cards) =>
            cards.GroupBy(c => c.Value).Where(g => g.Count() == 2).Select(g => g.Key).ToList();

        public override TieBreakerResults TieBreaker(List<Card> cardsOne, List<Card> cardsTwo)
        {
            var firstPairVals = GetHandValues(cardsOne);
            var secondPairVals = GetHandValues(cardsTwo);

            if (firstPairVals.Max() > secondPairVals.Max()) return TieBreakerResults.FirstWins;
            else if (firstPairVals.Max() < secondPairVals.Max()) return TieBreakerResults.SecondWins;

            if (firstPairVals.Min() > secondPairVals.Min()) return TieBreakerResults.FirstWins;
            else if (firstPairVals.Min() < secondPairVals.Min()) return TieBreakerResults.SecondWins;

            return TieBreakerResults.Tie;
        }


    }
}
