namespace PokerAnalyzer.Common;
public static class Constants
{
    public static readonly int HandSize = 5;
    public static readonly List<string> PlayerNames = new() { "Aaron", "Natalie", "Alaina", "Charlie", "Arthur", "Craig", "Allison", "Nick", "Emily", "AJ" };

    public static readonly Dictionary<int, string> ValuesToRanks = new() {
      { 2, "2" },
      { 3, "3" },
      { 4, "4" },
      { 5, "5" },
      { 6, "6" },
      { 7, "7" },
      { 8, "8" },
      { 9, "9" },
      { 10, "10" },
      { 11, "J" },
      { 12, "Q" },
      { 13, "K" },
      { 14, "A" },
    };
}
