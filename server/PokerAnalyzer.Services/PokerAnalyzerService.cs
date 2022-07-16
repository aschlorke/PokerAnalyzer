using PokerAnalyzer.Data.Models;

namespace PokerAnalyzer.Services;
public class PokerAnalyzerService : IPokerAnalyzerService
{
    public PokerGame GetNewGame ()
    {
        List<List<Card>> testHands = new () {
            new() {
                new(2, Suit.Diamonds),
                new(3, Suit.Diamonds),
                new(4, Suit.Diamonds),
                new(5, Suit.Diamonds),
                new(6, Suit.Diamonds)
            },
            new() {
                new(2, Suit.Clubs),
                new(3, Suit.Clubs),
                new(4, Suit.Clubs),
                new(5, Suit.Clubs),
                new(6, Suit.Clubs)
            }
        };
        return new PokerGame (0, new () {
            new("Aaron", testHands[0]),
            new("Natalie", testHands[1])
        });
    }

}
