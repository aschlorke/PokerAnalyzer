namespace PokerAnalyzer.Data.Models.Rules.CompositeHandRules
{
    public class StraightFlushRule : CompositeHandRule
    {
        public override string Name => "Straight Flush";
        public override int Value => 9;

        public StraightFlushRule(HandRule tiebreakingRule) : base(tiebreakingRule)
        {
            Rules = [new StraightRule(), new FlushRule()];
        }
    }
}
