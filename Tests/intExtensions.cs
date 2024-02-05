using Extensions;

namespace Tests
{
    public class intExtensions
    {
        [Theory]
        [InlineData(int.MinValue, false, "negative two billion one hundred forty-seven million four hundred eighty-three thousand six hundred forty-eight")]
        [InlineData(int.MinValue + 1, false, "negative two billion one hundred forty-seven million four hundred eighty-three thousand six hundred forty-seven")]
        [InlineData(0, false, "zero")]
        [InlineData(1, false, "one")]
        [InlineData(2, false, "two")]
        [InlineData(10, false, "ten")]
        [InlineData(15, false, "fifteen")]
        [InlineData(20, false, "twenty")]
        [InlineData(23, false, "twenty-three")]
        [InlineData(47, false, "forty-seven")]
        [InlineData(50, false, "fifty")]
        [InlineData(100, false, "one hundred")]
        [InlineData(104, false, "one hundred four")]
        [InlineData(115, false, "one hundred fifteen")]
        [InlineData(164, false, "one hundred sixty-four")]
        [InlineData(714, false, "seven hundred fourteen")]
        [InlineData(770, false, "seven hundred seventy")]
        [InlineData(777, false, "seven hundred seventy-seven")]
        [InlineData(1_000, false, "one thousand")]
        [InlineData(1_000, true, "one thousand")]
        [InlineData(1_001, false, "one thousand one")]
        [InlineData(1_001, true, "one thousand one")]
        [InlineData(1_011, false, "one thousand eleven")]
        [InlineData(1_011, true, "one thousand eleven")]
        [InlineData(1_080, false, "one thousand eighty")]
        [InlineData(1_080, true, "one thousand eighty")]
        [InlineData(1_100, false, "one thousand one hundred")]
        [InlineData(1_100, true, "eleven hundred")]
        [InlineData(1_101, false, "one thousand one hundred one")]
        [InlineData(1_101, true, "eleven hundred one")]
        [InlineData(1_111, false, "one thousand one hundred eleven")]
        [InlineData(1_111, true, "eleven hundred eleven")]
        [InlineData(1_137, false, "one thousand one hundred thirty-seven")]
        [InlineData(1_137, true, "eleven hundred thirty-seven")]
        [InlineData(2_137, false, "two thousand one hundred thirty-seven")]
        [InlineData(2_137, true, "twenty-one hundred thirty-seven")]
        [InlineData(10_000, false, "ten thousand")]
        [InlineData(10_000, true, "ten thousand")]
        [InlineData(12_000, false, "twelve thousand")]
        [InlineData(20_000, false, "twenty thousand")]
        [InlineData(98_000, false, "ninety-eight thousand")]
        [InlineData(98_123, false, "ninety-eight thousand one hundred twenty-three")]
        [InlineData(98_123, true, "ninety-eight thousand one hundred twenty-three")]
        [InlineData(100_000, false, "one hundred thousand")]
        [InlineData(101_100, false, "one hundred one thousand one hundred")]
        [InlineData(101_100, true, "one hundred one thousand one hundred")]
        [InlineData(342_000, false, "three hundred forty-two thousand")]
        [InlineData(717_000_000, false, "seven hundred seventeen million")]
        [InlineData(int.MaxValue, false, "two billion one hundred forty-seven million four hundred eighty-three thousand six hundred forty-seven")]
        public void AsText(int value, bool hundredsToTenThousand, string expected)
        {
            Assert.Equal(expected, value.AsText(hundredsToTenThousand));
        }

        [Theory]
        [InlineData(int.MinValue, "-2,147,483,648th")]
        [InlineData(int.MinValue + 1, "-2,147,483,647th")]
        [InlineData(-1, "-1st")]
        [InlineData(0, "0th")]
        [InlineData(1, "1st")]
        [InlineData(1_000, "1,000th")]
        [InlineData(int.MaxValue, "2,147,483,647th")]
        public void AsOrdinal(int value, string expected)
        {
            Assert.Equal(expected, value.AsOrdinal());
        }
    }
}