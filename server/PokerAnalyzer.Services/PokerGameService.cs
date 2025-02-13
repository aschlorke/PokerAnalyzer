using Microsoft.EntityFrameworkCore;
using PokerAnalyzer.Data.Models;
using PokerAnalyzer.Common;
using PokerAnalyzer.Data.Context;
using PokerAnalyzer.Services.Interfaces;

namespace PokerAnalyzer.Services;
public class PokerGameService : IPokerGameService
{
    private readonly IPokerHandRuleProvider _pokerHandRuleProvider;
    private readonly PokerAnalyzerContext _context;

    private readonly Deck _deck = new();

    public PokerGameService(IPokerHandRuleProvider pokerHandRuleProvider, PokerAnalyzerContext context)
    {
        _pokerHandRuleProvider = pokerHandRuleProvider;
        _context = context;
    }

    public async Task<PokerGameWithResults?> CreateGame(int numberOfPlayers)
    {
        // generate random players
        var playersList = Enumerable.Range(0, numberOfPlayers).Select(i => new Player() { Name = Constants.PlayerNames[i], PlayerId = PlayerId.Create() }).ToList();

        return await CreateGameInternal(playersList);
    }

    public async Task<PokerGameWithResults?> CreateGame(List<PlayerId> playerIds)
    {
        if (playerIds is { Count: 0 }) return null;

        var playersList = await _context.Players
            .Where(p => playerIds.Contains(p.PlayerId))
            .ToListAsync();

        if (playersList is { Count: 0 }) return null;

        return await CreateGameInternal(playersList);
    }

    public async Task<PokerGameWithResults> GetExistingGameById(int id)
    {
        var game = await _context.PokerGames
            .Include(pg => pg.PokerHands)
            .ThenInclude(p => p.Cards)
            .FirstAsync(pg => pg.PokerGameId == id);

        // map
        var gameWithResults = new PokerGameWithResults() { PokerHands = game.PokerHands, PokerGameId = game.PokerGameId, Results = game.DetermineResults(_pokerHandRuleProvider.GetRules().ToList()) };
        return gameWithResults;
    }

    public async Task<List<PokerGameWithResults>> GetExistingGames()
    {
        // Typically, just returning the entire db set would not be ideal. This set is expected to be small however, and is acceptable.
        var games = await _context.PokerGames
            .Include(pg => pg.PokerHands)
            .ThenInclude(p => p.Cards)
            .ToListAsync();

        // map
        var gamesWithResults = games.Select(g => new PokerGameWithResults() { PokerHands = g.PokerHands, PokerGameId = g.PokerGameId, Results = null }).ToList();

        foreach (var game in gamesWithResults)
        {
            game.Results = game.DetermineResults(_pokerHandRuleProvider.GetRules().ToList());
        }
        return gamesWithResults;
    }

    public async Task<List<int>> GetExistingGameIds()
    {
        return await _context.PokerGames.Select(pg => pg.PokerGameId).ToListAsync();
    }

    public async Task<bool> DeleteGameById(int id)
    {
        var found = await _context.PokerGames.FindAsync(id);
        if (found is not null)
        {
            _context.PokerGames.Remove(found);
            await _context.SaveChangesAsync();
        }

        return found is not null;
    }

    private async Task<PokerGameWithResults?> CreateGameInternal(List<Player> players)
    {
        _deck.ResetDeck();
        Dictionary<PlayerId, List<Card>> playerHands = new();

        PokerGameWithResults? game;
        try
        {
            // deal cards one by one to each player
            for (int i = 0; i < Constants.HandSize; i++)
            {
                foreach (var player in players)
                {
                    var id = player.PlayerId;
                    var card = _deck.DrawCard();
                    if (playerHands.ContainsKey(id))
                    {
                        playerHands[id].Add(card);
                    }
                    else
                    {
                        playerHands.Add(id, [card]);
                    }
                }
            }

            var playersList = players.Select(p =>
                new PokerHand()
                {
                    PlayerId = p.PlayerId,
                    Cards = playerHands[p.PlayerId].OrderBy(c => c.Value).ToList()
                }).ToList();

            game = new PokerGameWithResults { PokerHands = playersList };
        }
        catch (ArgumentOutOfRangeException)
        {
            game = null;
        }


        if (game is null) return game;

        _context.PokerGames.Add(game);
        await _context.SaveChangesAsync();

        game.Results = game.DetermineResults(_pokerHandRuleProvider.GetRules().ToList());
        return game;
    }
}
