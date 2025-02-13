using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokerAnalyzer.Data.Configurations.Extensions;
using PokerAnalyzer.Data.Models;

public class PokerGameConfiguration : IEntityTypeConfiguration<PokerGame>
{
    public void Configure(EntityTypeBuilder<PokerGame> builder)
    {
        builder.HasKey(p => p.PokerGameId);
        builder.Property(p => p.PokerGameId).ValueGeneratedOnAdd();
        builder.OwnsMany(p => p.PokerHands, h =>
        {
            h.ConfigureStronglyTypedKey(h => h.PlayerId);
            h.WithOwner().HasForeignKey("PokerGameId");
            h.Property<int>("PokerHandId");
            h.HasKey("PokerHandId");

            h.OwnsMany(h => h.Cards, c =>
            {
                c.Property<int>("PokerHandId");
                c.WithOwner().HasForeignKey("PokerHandId");
                c.Property<int>("CardId");
                c.HasKey("CardId");
            });
        });

    }
}
