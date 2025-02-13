using Microsoft.EntityFrameworkCore;
using PokerAnalyzer.Data.Models;

namespace PokerAnalyzer.Data.Context;

public class PokerAnalyzerContext : DbContext
{
    public DbSet<PokerGame> PokerGames { get; set; }
    public DbSet<Player> Players { get; set; }

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
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PokerAnalyzerContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

