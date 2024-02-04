using Extensions;

namespace Tests
{
    public class IComparableExtensions
    {
        [Theory]

        // Proper closed
        [InlineData(1, 2, 7, true, true, false)]
        [InlineData(2, 2, 7, true, true, true)]
        [InlineData(5, 2, 7, true, true, true)]
        [InlineData(7, 2, 7, true, true, true)]
        [InlineData(8, 2, 7, true, true, false)]

        // Proper left open
        [InlineData(1, 2, 7, false, true, false)]
        [InlineData(2, 2, 7, false, true, false)]
        [InlineData(5, 2, 7, false, true, true)]
        [InlineData(7, 2, 7, false, true, true)]
        [InlineData(8, 2, 7, false, true, false)]

        // Proper right open
        [InlineData(1, 2, 7, true, false, false)]
        [InlineData(2, 2, 7, true, false, true)]
        [InlineData(5, 2, 7, true, false, true)]
        [InlineData(7, 2, 7, true, false, false)]
        [InlineData(8, 2, 7, true, false, false)]

        // Proper open
        [InlineData(1, 2, 7, false, false, false)]
        [InlineData(2, 2, 7, false, false, false)]
        [InlineData(5, 2, 7, false, false, true)]
        [InlineData(7, 2, 7, false, false, false)]
        [InlineData(8, 2, 7, false, false, false)]

        // Degenerate closed
        [InlineData(0, 1, 1, true, true, false)]
        [InlineData(1, 1, 1, true, true, true)]
        [InlineData(2, 1, 1, true, true, false)]

        // Degenerate open
        [InlineData(0, 1, 1, false, false, false)]
        [InlineData(1, 1, 1, false, false, false)]
        [InlineData(2, 1, 1, false, false, false)]
        public void InRange_NoThrows(int value, int minimum, int maximum, bool minInclusive, bool maxInclusive, bool expected)
        {
            Assert.Equal(value.InRange(minimum, maximum, minInclusive, maxInclusive), expected);
        }

        [Theory]

        // Degenerate left open
        [InlineData(0, 1, 1, false, true)]
        [InlineData(1, 1, 1, false, true)]
        [InlineData(2, 1, 1, false, true)]

        // Degenerate right open
        [InlineData(0, 1, 1, true, false)]
        [InlineData(1, 1, 1, true, false)]
        [InlineData(2, 1, 1, true, false)]

        // Inverted
        [InlineData(1, 7, 2, true, true)]
        [InlineData(2, 7, 2, true, true)]
        [InlineData(5, 7, 2, true, true)]
        [InlineData(7, 7, 2, true, true)]
        [InlineData(8, 7, 2, true, true)]
        public void InRange_Throws(int value, int minimum, int maximum, bool minInclusive, bool maxInclusive)
        {
            Assert.Throws<ArgumentException>(() => value.InRange(minimum, maximum, minInclusive, maxInclusive));
        }
    }
}