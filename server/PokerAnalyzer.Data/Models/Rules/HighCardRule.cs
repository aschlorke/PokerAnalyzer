using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models.Rules
{
    public class HighCardRule : HandRule
    {
        public override string Name => "High Card";
        public override int Value => 1;
        public override bool HasHand(List<Card> cards) => true;

        public override TieBreakerResults TieBreaker(List<Card> cardsOne, List<Card> cardsTwo)
        {
            var cardsOneVals = cardsOne.OrderByDescending(c => c.Value).Select(c => c.Value).ToList();
            var cardsTwoVals = cardsTwo.OrderByDescending(c => c.Value).Select(c => c.Value).ToList();
            for (int i = 0; i < cardsOneVals.Count(); i++)
            {
                if (cardsOneVals[i] == cardsTwoVals[i]) continue;
                else if (cardsOneVals[i] > cardsTwoVals[i]) return TieBreakerResults.FirstWins;
                else return TieBreakerResults.SecondWins;
            }
            return TieBreakerResults.Tie;
        }
    }
}
