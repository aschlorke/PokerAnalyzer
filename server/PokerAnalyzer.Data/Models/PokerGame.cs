using Newtonsoft.Json;

namespace PokerAnalyzer.Data.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class PokerGame
    {
        [JsonProperty]
        public int Id { get; private set; }

        [JsonProperty]
        public List<Player> Players { get; private set; }

        [JsonProperty]
        public string Winner { get; private set; }

        public PokerGame(int id, List<Player> players, string winner)
        {
            Id = id;
            Players = players;
            Winner = winner;
        }
    }
}
