
namespace PokerAnalyzer.Data.Models;

public class Player
{
    public required PlayerId PlayerId { get; init; }
    public required string Name { get; init; }

    public static Player Create(string name) => new() { Name = name, PlayerId = PlayerId.Create() };
}

public readonly record struct PlayerId(Guid Value) : ITypedKey
{
    public static PlayerId Empty => new() { Value = Guid.Empty };
    public static PlayerId Create() => new() { Value = Guid.CreateVersion7() };
}