namespace Extensions
{
    public static class IComparableExtensions
    {
        public static bool InRange<T>(this T comparable, T minimum, T maximum, bool minInclusive = true, bool maxInclusive = true) where T : IComparable<T>
        {
            ArgumentOutOfRangeException.ThrowIfGreaterThan(minimum, maximum);
            if (minimum.Equals(maximum) && minInclusive != maxInclusive) throw new ArgumentException("Half-open degenerate interval specified.");

            var minComp = comparable.CompareTo(minimum);
            if (minComp < 0 || (minComp == 0 && !minInclusive)) return false;

            var maxComp = comparable.CompareTo(maximum);
            if (maxComp > 0 || (maxComp == 0 && !maxInclusive)) return false;

            return true;
        }
    }
}