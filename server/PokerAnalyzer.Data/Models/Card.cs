using Newtonsoft.Json;

namespace PokerAnalyzer.Data.Models
{
    [JsonObject (MemberSerialization.OptIn)]
    public class Card
    {
        [JsonProperty]
        public int Value { get; private set; }

        [JsonProperty]
        public Suit Suit { get; private set; }

        public Card (int value, Suit suit)
        {
            Value = value;
            Suit = suit;
        }
    }
}
