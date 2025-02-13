using System.Linq.Expressions;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PokerAnalyzer.Data.Configurations.Extensions;

public static class PropertyBuilderExtensions
{
    public static EntityTypeBuilder<TRef> ConfigureStronglyTypedKey<TKey, TRef>(this EntityTypeBuilder<TRef> builder, Expression<Func<TRef, TKey>> expression)
        where TRef : class
        where TKey : struct, ITypedKey
    {
        builder.Property(expression)
            .HasColumnType("uniqueidentifier")
            .HasConversion<TypedKeyConverter<TKey>>();

        return builder;
    }
    public static OwnedNavigationBuilder<TOwner, TOwnee> ConfigureStronglyTypedKey<TKey, TOwner, TOwnee>(this OwnedNavigationBuilder<TOwner, TOwnee> builder, Expression<Func<TOwnee, TKey>> expression)
        where TOwner : class
        where TOwnee : class
        where TKey : struct, ITypedKey
    {
        builder.Property(expression)
            .HasColumnType("uniqueidentifier")
            .HasConversion<TypedKeyConverter<TKey>>();

        return builder;
    }
}