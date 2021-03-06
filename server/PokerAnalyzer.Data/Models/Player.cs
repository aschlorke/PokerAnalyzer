using Newtonsoft.Json;

namespace PokerAnalyzer.Data.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Player
    {
        [JsonProperty]
        public string Name { get; private set; }

        [JsonProperty]
        public List<Card> Cards { get; private set; }

        public Player(string name, List<Card> cards)
        {
            Name = name;
            Cards = cards;
        }
    }
}
