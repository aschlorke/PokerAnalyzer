using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models.Rules
{
    public class StraightRule : HandRule
    {
        public override string Name => "Straight";
        public override int Value => 5;

        public override bool HasHand(List<Card> cards)
        {
            // cards should be sorted already
            List<int> cardVals = cards.OrderBy(c => c.Value).Select(c => c.Value).ToList();
            int lastVal = cardVals[0];
            for (int i = 1; i < cardVals.Count(); i++)
            {
                if (cardVals[i] != lastVal + 1) return false;
                lastVal = cardVals[i];
            }

            return true;
        }
        public override TieBreakerResults TieBreaker(List<Card> cardsOne, List<Card> cardsTwo)
        {
            var firstHandHighest = cardsOne.Max(c => c.Value);
            var secondHandHighest = cardsOne.Max(c => c.Value);

            if (firstHandHighest > secondHandHighest) return TieBreakerResults.FirstWins;
            else if (firstHandHighest < secondHandHighest) return TieBreakerResults.SecondWins;
            return TieBreakerResults.Tie;
        }


    }
}
