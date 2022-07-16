using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models.Rules.CompositeHandRules
{
    public class FullHouseRule : CompositeHandRule
    {
        public override string Name => "Full House";
        public override int Value => 8;
        public FullHouseRule(List<HandRule> compositeRules, HandRule tiebreakingRule) : base(compositeRules, tiebreakingRule)
        {
        }
    }
}
