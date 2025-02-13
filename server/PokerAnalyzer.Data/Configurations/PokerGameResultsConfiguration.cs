using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokerAnalyzer.Data.Models;

public class PokerGameResultsConfiguration : IEntityTypeConfiguration<PokerGameResults>
{
    public void Configure(EntityTypeBuilder<PokerGameResults> builder)
    {
        // For now, results are computed only. Unfortunately, EF still wants the
        // rest of the entity configured.
        builder.ToTable("PokerGameResults", t => t.ExcludeFromMigrations());
        builder.HasNoKey();
        builder.Property(p => p.Winner)
            .HasColumnType("uniqueidentifier")
            .HasConversion<TypedKeyConverter<PlayerId>>();
    }
}
