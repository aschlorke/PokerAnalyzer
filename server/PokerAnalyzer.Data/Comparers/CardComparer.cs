using PokerAnalyzer.Data.Models;

namespace PokerAnalyzer.Data.Comparers
{
    public class CardComparer : IComparer<Card>
    {
        public int Compare(Card? x, Card? y)
        {
            if (object.ReferenceEquals(x, y)) return 0;
            if (x == null) return -1;
            if (y == null) return 1;
            return x.Value.CompareTo(y.Value);
        }
    }
}
