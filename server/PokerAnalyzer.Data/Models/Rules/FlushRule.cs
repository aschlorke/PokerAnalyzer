using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models.Rules
{
    public class FlushRule : HandRule
    {
        public override string Name => "Flush";
        public override int Value => 6;

        public override bool HasHand(List<Card> cards) =>
            cards.All(c => cards.First().Suit == c.Suit);

        public override TieBreakerResults TieBreaker(List<Card> cardsOne, List<Card> cardsTwo)
        {
            var highCard = new HighCardRule();
            return highCard.TieBreaker(cardsOne, cardsTwo);
        }
    }
}
