using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public class TypedKeyConverter<T> : ValueConverter<T, Guid>
    where T : ITypedKey, new()
{
    public TypedKeyConverter()
        : base(
            v => v.Value,
            v => new T { Value = v })
    {
    }
}
