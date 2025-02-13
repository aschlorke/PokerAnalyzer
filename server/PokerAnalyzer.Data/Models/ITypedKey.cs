public interface ITypedKey
{
    public Guid Value { get; init; }
}

public record EmptyKey() : ITypedKey
{
    public Guid Value => Guid.Empty;

    Guid ITypedKey.Value { get => Value; init => throw new NotImplementedException(); }
}