using Newtonsoft.Json;

namespace PokerAnalyzer.Data.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PokerGameResults
    {
        [JsonProperty]
        public string Winner { get; private set; }

        [JsonProperty]
        public string WinningHand { get; private set; }

        public PokerGameResults(string winner, string winningHand)
        {
            Winner = winner;
            WinningHand = winningHand;
        }
    }
}
