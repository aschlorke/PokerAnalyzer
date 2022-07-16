using PokerAnalyzer.Data.Models;
using PokerAnalyzer.Common;

namespace PokerAnalyzer.Services;
public class PokerAnalyzerService : IPokerAnalyzerService
{
    private Dictionary<int, PokerGame> Games = new();

    private static int id = 0;
    private Deck deck = new();

    public PokerGame GetNewGame() => CreateGame();

    public PokerGame GetExistingGameById(int id) => Games[id];

    public bool DeleteGameById(int id) => Games.Remove(id);

    private PokerGame CreateGame()
    {
        deck.ResetDeck();
        Dictionary<string, List<Card>> players = new();

        // deal cards one by one to each player
        for (int i = 0; i < Constants.HandSize; i++)
        {
            foreach (var player in Constants.PlayerNames)
            {
                var card = deck.DrawCard();
                if (players.ContainsKey(player))
                {
                    players[player].Add(card);
                }
                else
                {
                    players.Add(player, new() { card });
                }
            }
        }

        PokerGame game = new PokerGame(id, players.Select(p => new Player(p.Key, p.Value)).ToList());
        Games.Add(id, game);

        id++;

        return game;
    }
}
