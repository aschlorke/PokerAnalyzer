using PokerAnalyzer.Data.Models;
using PokerAnalyzer.Common;
using PokerAnalyzer.Data.Comparers;

namespace PokerAnalyzer.Services;
public class PokerAnalyzerService : IPokerAnalyzerService
{
    private Dictionary<int, PokerGame> Games = new();

    private static int id = 0;
    private readonly CardComparer comparer = new();
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

        var playersList = players.Select(p =>
        {
            p.Value.Sort(comparer);
            return new Player(p.Key, p.Value);
        }).ToList();

        var winner = DetermineWinner(playersList);

        PokerGame game = new PokerGame(id, playersList, "");
        Games.Add(id, game);

        id++;

        return game;
    }

    private string DetermineWinner(IList<Player> players)
    {
        Dictionary<string, HandResultType> handResults = new();

        foreach (var player in players)
        {
            // check hand results

        }
        return Constants.PlayerNames[0];
    }


    // TODO: Find a better home for this
    private bool CheckNumPairs(List<Card> cards, int numPairs) => cards.GroupBy(c => c.Value).Count(g => g.Count() == 2) == numPairs;
    private bool CheckPair(List<Card> cards) => CheckNumPairs(cards, 1);
    private bool CheckTwoPair(List<Card> cards) => CheckNumPairs(cards, 2);
    private bool CheckThreeOfAKind(List<Card> cards) => cards.GroupBy(c => c.Value).Any(g => g.Count() == 3);
    private bool CheckStraight(List<Card> cards) => false; // TODO
    private bool CheckFlush(List<Card> cards) => cards.All(c => cards.First().Suit == c.Suit);
    private bool CheckFullHouse(List<Card> cards) => CheckThreeOfAKind(cards) && CheckPair(cards);
    private bool CheckFourOfAKind(List<Card> cards) => cards.GroupBy(c => c.Value).Any(g => g.Count() == 4);
    private bool CheckStraightFlush(List<Card> cards) => CheckStraight(cards) && CheckFlush(cards);
}
