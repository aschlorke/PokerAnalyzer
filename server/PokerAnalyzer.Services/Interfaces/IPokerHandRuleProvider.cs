using PokerAnalyzer.Data.Models.Rules;

namespace PokerAnalyzer.Services.Interfaces;

public interface IPokerHandRuleProvider
{
    public IEnumerable<HandRule> GetRules();
}