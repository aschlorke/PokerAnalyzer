using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models.Rules.CompositeHandRules
{
    public class FullHouseRule : CompositeHandRule
    {
        public override string Name => "Full House";
        public override int Value => 8;
        public FullHouseRule(HandRule tiebreakingRule) : base(tiebreakingRule)
        {
            Rules = [new ThreeOfAKindRule(), new PairRule()];
        }
    }
}
