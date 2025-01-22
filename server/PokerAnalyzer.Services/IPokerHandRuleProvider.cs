using PokerAnalyzer.Data.Models.Rules;

namespace PokerAnalyzer.Services;

public interface IPokerHandRuleProvider
{
    public IEnumerable<HandRule> GetRules();
}