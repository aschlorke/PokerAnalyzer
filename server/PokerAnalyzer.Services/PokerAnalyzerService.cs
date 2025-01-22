using PokerAnalyzer.Data.Models;
using PokerAnalyzer.Common;
using PokerAnalyzer.Data.Models.Rules;
using PokerAnalyzer.Data.Models.Rules.CompositeHandRules;
using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Services;
public class PokerAnalyzerService : IPokerAnalyzerService
{
    private readonly IPokerHandRuleProvider _pokerHandRuleProvider;
    private readonly Dictionary<int, PokerGame> _games = new();

    private static int _id = 0;
    private readonly Deck _deck = new();

    public PokerAnalyzerService(IPokerHandRuleProvider pokerHandRuleProvider)
    {
        _pokerHandRuleProvider = pokerHandRuleProvider;
    }

    public PokerGame? CreateGame(int numberOfPlayers) => CreateGameInternal(numberOfPlayers);

    public PokerGame GetExistingGameById(int id) => _games[id];
    public List<PokerGame> GetExistingGames() => _games.Values.ToList();
    public List<int> GetExistingGameIds() => _games.Keys.ToList();

    public bool DeleteGameById(int id) => _games.Remove(id);


    // These private methods should have a better home.
    private PokerGame? CreateGameInternal(int numberOfPlayers)
    {
        _deck.ResetDeck();
        Dictionary<string, List<Card>> players = new();

        PokerGame? game = null;
        try
        {
            // deal cards one by one to each player
            for (int i = 0; i < Constants.HandSize; i++)
            {
                for (int j = 0; j < numberOfPlayers; j++)
                {
                    var player = Constants.PlayerNames[j];
                    var card = _deck.DrawCard();
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

            var playersList = players.Select(p => new Player() { Name = p.Key, Cards = p.Value.OrderBy(c => c.Value).ToList()} ).ToList();
            var results = DetermineResults(playersList);

            game = new() { Id = _id, Players = playersList, Results = results };
            _games.Add(_id, game);

            _id++;
        }
        catch (ArgumentOutOfRangeException _)
        {
            game = null;
        }

        return game;

    }


    private PokerGameResults DetermineResults(IList<Player> players)
    {
        Dictionary<Player, HandRule> handResults = new();

        foreach (var player in players)
        {
            foreach (var rule in _pokerHandRuleProvider.GetRules())
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
            return new() {Winner = winner.Name, WinningHand = handResults[winner].Name};
        }
        else
        {
            return new() {Winner = "Draw", WinningHand = "There was a draw"};
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
            return new() { Winner = winningPlayer.Name, WinningHand = tiedRule.Name};
        }
        else
        {
            return new() {Winner = "Draw", WinningHand = "Both hands were the same"};
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
