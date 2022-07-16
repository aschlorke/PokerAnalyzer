using Newtonsoft.Json;

namespace PokerAnalyzer.Data.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Hand
    {
        [JsonProperty]
        public List<Card> Cards { get; private set; }

        public Hand(List<Card> cards)
        {
            Cards = cards;
        }
    }
}
