using Microsoft.EntityFrameworkCore;
using PokerAnalyzer.Data.Context;
using PokerAnalyzer.Data.Models;
using PokerAnalyzer.Services.Interfaces;

namespace PokerAnalyzer.Services;
public class PokerPlayerService(PokerAnalyzerContext context) : IPokerPlayerService
{

    public async Task AddPlayer(Player player)
    {
        context.Players.Add(player);
        await context.SaveChangesAsync();
    }

    public async Task<bool> DeletePlayer(PlayerId playerId)
    {
        var player = context.Players.Find(playerId);
        if (player is not null)
        {
            context.Players.Remove(player);
            await context.SaveChangesAsync();
        }

        return player is not null;
    }

    public async Task<Player> GetPlayerById(PlayerId playerId, CancellationToken cancellationToken = default)
    {
        return await context.Players.SingleAsync(p => p.PlayerId == playerId);
    }

    public async Task<List<Player>> GetPlayers(CancellationToken cancellationToken = default)
    {
        return await context.Players
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }

    public async Task<List<Player>> GetPlayersByGameId(int gameId, CancellationToken cancellationToken = default)
    {
        var playerIds = await context.PokerGames
            .Where(g => g.PokerGameId == gameId)
            .SelectMany(g => g.PokerHands.Select(ph => ph.PlayerId))
            .ToListAsync();

        if (playerIds is null or { Count: 0 }) return [];

        return await context.Players
            .Where(p => playerIds.Contains(p.PlayerId))
            .ToListAsync();
    }
}