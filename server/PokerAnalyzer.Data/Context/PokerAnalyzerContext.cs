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

        modelBuilder.Entity<Card>(b =>
        {
            b.HasKey(c => c.CardId);
            b.Property(c => c.CardId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Player>(b =>
        {
            b.HasKey(p => p.PlayerId);
            b.Property(p => p.PlayerId).ValueGeneratedOnAdd();
        });
        modelBuilder.Entity<PokerGame>(b =>
        {
            b.HasKey(p => p.PokerGameId);
            b.Property(p => p.PokerGameId).ValueGeneratedOnAdd();
        });
    }
}

