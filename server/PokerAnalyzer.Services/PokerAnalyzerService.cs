using PokerAnalyzer.Data.Models;
using PokerAnalyzer.Common;
using PokerAnalyzer.Data.Models.Rules;
using PokerAnalyzer.Data.Models.Rules.CompositeHandRules;
using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Services;
public class PokerAnalyzerService : IPokerAnalyzerService
{
    private Dictionary<int, PokerGame> Games = new();
    private List<HandRule> rules = new();

    private static int id = 0;
    private Deck deck = new();

    public PokerGame GetNewGame() => CreateGame();

    public PokerGame GetExistingGameById(int id) => Games[id];

    public bool DeleteGameById(int id) => Games.Remove(id);

    public PokerAnalyzerService()
    {
        var highCard = new HighCardRule();
        var pair = new PairRule();
        var twoPair = new TwoPairRule();
        var threeOfAKind = new ThreeOfAKindRule();
        var straight = new StraightRule();
        var flush = new FlushRule();
        var fullHouse = new FullHouseRule(new() { threeOfAKind, pair }, threeOfAKind);
        var fourOfAKind = new FourOfAKindRule();
        var straightFlush = new StraightFlushRule(new() { straight, flush }, straight);

        rules = new List<HandRule>() {
            highCard,
            pair,
            twoPair,
            threeOfAKind,
            straight,
            flush,
            fullHouse,
            fourOfAKind,
            straightFlush
        }.OrderByDescending(r => r.Value).ToList();
    }

    // private PokerGame CreateGame()
    // {
    // deck.ResetDeck();
    // Dictionary<string, List<Card>> players = new();

    // // deal cards one by one to each player
    // for (int i = 0; i < Constants.HandSize; i++)
    // {
    //     foreach (var player in Constants.PlayerNames)
    //     {
    //         var card = deck.DrawCard();
    //         if (players.ContainsKey(player))
    //         {
    //             players[player].Add(card);
    //         }
    //         else
    //         {
    //             players.Add(player, new() { card });
    //         }
    //     }
    // }

    // var playersList = players.Select(p => new Player(p.Key, p.Value.OrderBy(c => c.Value).ToList())).ToList();
    // var results = DetermineResults(playersList);

    // PokerGame game = new (id, playersList, results);
    // Games.Add(id, game);

    // id++;

    // return game;

    // }

    private PokerGame CreateGame()
    {
        List<Player> players = new();
        List<List<Card>> testHands = new() {
            new() {
                new("2", 2, Suit.Diamonds),
                new("2", 2, Suit.Clubs),
                new("2", 2, Suit.Hearts),
                new("3", 3, Suit.Diamonds),
                new("4", 4, Suit.Clubs),
            },
            new() {
                new("2", 2, Suit.Diamonds),
                new("2", 2, Suit.Clubs),
                new("2", 2, Suit.Hearts),
                new("3", 3, Suit.Diamonds),
                new("5", 5, Suit.Clubs),
            },
            new() {
                new("2", 2, Suit.Diamonds),
                new("2", 2, Suit.Clubs),
                new("2", 2, Suit.Hearts),
                new("3", 3, Suit.Diamonds),
                new("6", 6, Suit.Clubs),
            },
        };

        for (int i = 0; i < Constants.PlayerNames.Count; i++)
        {
            players.Add(new Player(Constants.PlayerNames[i], testHands[i]));
        }

        return new PokerGame(id, players, DetermineResults(players));
    }


    private PokerGameResults DetermineResults(IList<Player> players)
    {
        Dictionary<Player, HandRule> handResults = new();

        foreach (var player in players)
        {
            foreach (var rule in rules)
            {
                if (rule.HasHand(player.Cards))
                {
                    handResults.Add(player, rule);
                    break;
                }
            }
        }
        var maxScore = handResults.Values.Select(r => r.Value).Max();
        var tiedPlayers = handResults.Where(kvp => kvp.Value.Value == maxScore).Select(kvp => kvp.Key).ToList();
        if (tiedPlayers.Count() > 1)
        {
            return DetermineResultsFromTies(tiedPlayers, handResults[tiedPlayers[0]]);
        }
        else if (tiedPlayers.Count() == 1)
        {
            var winner = tiedPlayers[0];
            return new(winner.Name, handResults[winner].Name);
        }
        else
        {
            return new("Draw", "Both hands were the same");
        }

    }
    private PokerGameResults DetermineResultsFromTies(List<Player> playersToCheck, HandRule tiedRule)
    {
        Player winningPlayer = playersToCheck[0];
        HashSet<Player> tiedPlayers = new();

        // check if any players have matching results
        // tie break for all players; assume first player is in the lead first
        for (int i = 1; i < playersToCheck.Count; i++)
        {
            var tempWinner = FindWinnerForRule(winningPlayer, playersToCheck[i], tiedRule);
            if (tempWinner == null)
            {
                tempWinner = FindWinnerForRule(winningPlayer, playersToCheck[i], new HighCardRule());

                if (tempWinner == null)
                {
                    tiedPlayers.Add(winningPlayer);
                    tiedPlayers.Add(playersToCheck[i]);
                }
            }

            if (tempWinner != null) winningPlayer = tempWinner;
        }

        // if after checking everything there is still a tie, just set the 
        // winner to "Draw"
        if (winningPlayer != null && !tiedPlayers.Contains(winningPlayer))
        {
            return new(winningPlayer.Name, tiedRule.Name);
        }
        else
        {
            return new("Draw", "Both hands were the same");
        }
    }

    private Player? FindWinnerForRule(Player player1, Player player2, HandRule rule)
    {
        var result = rule.TieBreaker(player1.Cards, player2.Cards);
        if (result == TieBreakerResults.FirstWins) return player1;
        else if (result == TieBreakerResults.SecondWins) return player2;
        return null;
    }
}
