using PokerAnalyzer.Data.Models.Rules;
using PokerAnalyzer.Data.Models.Rules.Enums;

namespace PokerAnalyzer.Data.Models;

public class PokerGame
{
    public int PokerGameId { get; private set; }
    public PokerGameResults? Results { get; set; }


    public required List<Player> Players { get; init; }

}

public static class PokerGameExtensions
{
    public static PokerGameResults DetermineResults(this PokerGame game, List<HandRule> handRules)
    {
        Dictionary<Player, HandRule> handResults = new();

        foreach (var player in game.Players)
        {
            foreach (var rule in handRules)
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
            return new() { Winner = winner.Name, WinningHand = handResults[winner].Name };
        }
        else
        {
            return new() { Winner = "Draw", WinningHand = "There was a draw" };
        }

    }
    private static PokerGameResults DetermineResultsFromTies(List<Player> playersToCheck, HandRule tiedRule)
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
        if (tiedPlayers.Contains(winningPlayer))
        {
            return new() { Winner = "Draw", WinningHand = "Both hands were the same" };
        }
        else
        {
            return new() { Winner = winningPlayer.Name, WinningHand = tiedRule.Name };
        }
    }

    private static Player? FindWinnerForRule(Player player1, Player player2, HandRule rule)
    {
        var result = rule.TieBreaker(player1.Cards, player2.Cards);
        return result switch
        {
            TieBreakerResults.FirstWins => player1,
            TieBreakerResults.SecondWins => player2,
            _ => null
        };
    }
}

