using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokerAnalyzer.Data.Configurations.Extensions;
using PokerAnalyzer.Data.Models;

public class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        builder.HasKey(x => x.PlayerId);
        builder.ConfigureStronglyTypedKey(x => x.PlayerId);
    }
}
