using Microsoft.EntityFrameworkCore;
using PokerAnalyzer.Data.Models;

namespace PokerAnalyzer.Data.Context;

public class PokerAnalyzerContext : DbContext
{
    public DbSet<PokerGame> PokerGames { get; set; }

    private string DbPath { get; }

    public PokerAnalyzerContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "poker-analyzer.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // TODO: Better normalize this data. Currently, every game creates new players, and cards are created for each player for each game.
        // While for this small app, space savings may be minimal, we could have a couple of many to many tables that
        // link player the player table to the games table, and the cards table to the player table. That way, players would only
        // be unique and tracked across games, as would cards. That would allow for easier tracking of statistics across games
        modelBuilder.Entity<Player>(b =>
        {
            b.HasKey(p => p.PlayerId);
            b.Property(p => p.PlayerId).ValueGeneratedOnAdd();
            b.OwnsMany(p => p.Cards, a =>
            {
                a.WithOwner().HasForeignKey("PlayerId");
                a.Property<int>("CardId");
                a.HasKey("CardId");
            });
        });
        modelBuilder.Entity<PokerGame>(b =>
        {
            b.HasKey(p => p.PokerGameId);
            b.Property(p => p.PokerGameId).ValueGeneratedOnAdd();
        });
    }
}

