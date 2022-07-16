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
        public PokerGameResults Results { get; private set; }

        public PokerGame(int id, List<Player> players, PokerGameResults results)
        {
            Id = id;
            Players = players;
            Results = results;
        }
    }
}
