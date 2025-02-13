using PokerAnalyzer.Data.Models.Rules;
using PokerAnalyzer.Data.Models.Rules.CompositeHandRules;
using PokerAnalyzer.Services.Interfaces;

namespace PokerAnalyzer.Services;

public class PokerHandRuleProvider : IPokerHandRuleProvider
{
    public IEnumerable<HandRule> GetRules()
    {
        var highCard = new HighCardRule();
        var pair = new PairRule();
        var twoPair = new TwoPairRule();
        var threeOfAKind = new ThreeOfAKindRule();
        var straight = new StraightRule();
        var flush = new FlushRule();
        var fullHouse = new FullHouseRule(threeOfAKind);
        var fourOfAKind = new FourOfAKindRule();
        var straightFlush = new StraightFlushRule(straight);

        return new List<HandRule>() {
            highCard,
            pair,
            twoPair,
            threeOfAKind,
            straight,
            flush,
            fullHouse,
            fourOfAKind,
            straightFlush
        }.OrderByDescending(r => r.Value);
    }
}