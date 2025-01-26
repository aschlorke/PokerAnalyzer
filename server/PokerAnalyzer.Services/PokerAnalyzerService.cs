using Microsoft.EntityFrameworkCore;
using PokerAnalyzer.Data.Models;
using PokerAnalyzer.Common;
using PokerAnalyzer.Data.Models.Rules;
using PokerAnalyzer.Data.Models.Rules.Enums;
using PokerAnalyzer.Data.Context;

namespace PokerAnalyzer.Services;
public class PokerAnalyzerService : IPokerAnalyzerService
{
    private readonly IPokerHandRuleProvider _pokerHandRuleProvider;
    private readonly PokerAnalyzerContext _context;

    private readonly Deck _deck = new();

    public PokerAnalyzerService(IPokerHandRuleProvider pokerHandRuleProvider, PokerAnalyzerContext context)
    {
        _pokerHandRuleProvider = pokerHandRuleProvider;
        _context = context;
    }

    public async Task<PokerGame?> CreateGame(int numberOfPlayers)
    {
        var game = CreateGameInternal(numberOfPlayers);
        if (game is null) return game;

        _context.PokerGames.Add(game);
        await _context.SaveChangesAsync();

        return game;
    }

    // TODO: Don't actually store the results in the DB, but rather calculate them after fetching the game
    public async Task<PokerGame> GetExistingGameById(int id)
    {
        var game = await _context.PokerGames
            .Include(pg => pg.Players)
            .ThenInclude(p => p.Cards)
            .FirstAsync(pg => pg.PokerGameId == id);

        // Directly setting the result property is a bit of a stop gap from a refactor where the results were computed on game instantiation.
        game.Results = game.DetermineResults(_pokerHandRuleProvider.GetRules().ToList());
        return game;
    }

    public async Task<List<PokerGame>> GetExistingGames()
    {
        // Typically, just returning the entire db set would not be ideal. This set is expected to be small however, and is acceptable.
        var games = await _context.PokerGames
            .Include(pg => pg.Players)
            .ThenInclude(p => p.Cards)
            .ToListAsync();

        foreach (var game in games)
        {
            game.Results = game.DetermineResults(_pokerHandRuleProvider.GetRules().ToList());
        }
        return games;
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


    // These private methods should have a better home.
    private PokerGame? CreateGameInternal(int numberOfPlayers)
    {
        _deck.ResetDeck();
        Dictionary<string, List<Card>> players = new();

        PokerGame? game;
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
                        players.Add(player, [card]);
                    }
                }
            }

            var playersList = players.Select(p => new Player() { Name = p.Key, Cards = p.Value.OrderBy(c => c.Value).ToList() }).ToList();

            game = new PokerGame { Players = playersList };
        }
        catch (ArgumentOutOfRangeException)
        {
            game = null;
        }

        return game;
    }
}
