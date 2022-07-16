using Newtonsoft.Json;

namespace PokerAnalyzer.Data.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Card
    {
        [JsonProperty]
        public string Rank { get; private set; }

        [JsonProperty]
        public int Value { get; private set; }

        [JsonProperty]
        public Suit Suit { get; private set; }


        public Card(string rank, int value, Suit suit)
        {
            Rank = rank;
            Value = value;
            Suit = suit;
        }
    }
}
