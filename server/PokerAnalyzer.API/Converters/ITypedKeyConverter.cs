using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PokerAnalyzer.API.Converters;

public class ITypedKeyConverter<T> : JsonConverter<T>
    where T : struct, ITypedKey
{
    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.Value.ToString());
    }

    public override bool CanConvert(Type objectType)
    {
        return objectType.IsAssignableTo(typeof(T));
    }

    public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var readerVal = reader.GetString();
        if (readerVal is null) return new();

        // this creates an unintended side effect of silently requiring all ITypeKeys to have a constructor that takes
        // in the guid as their value. Re-evaluate this decision to see if there is a better option that allows seemless
        // communications.
        var guid = Guid.Parse(readerVal);
        var instance = Activator.CreateInstance(typeToConvert, guid);

        if (instance is T tInstance) return tInstance;
        return new();
    }
}
