using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models.Rules.CompositeHandRules
{
    public abstract class CompositeHandRule : HandRule
    {
        public List<HandRule> Rules { get; protected set; } = new();
        protected HandRule tiebreakingRule = new HighCardRule();

        public CompositeHandRule(List<HandRule> compositeRules, HandRule tiebreakingRule)
        {
            Rules = compositeRules;
            this.tiebreakingRule = tiebreakingRule;
        }

        public override bool HasHand(List<Card> cards) =>
            Rules.All(r => r.HasHand(cards));

        public override TieBreakerResults TieBreaker(List<Card> cardsOne, List<Card> cardsTwo)
        {
            return tiebreakingRule.TieBreaker(cardsOne, cardsTwo);
        }

    }
}
