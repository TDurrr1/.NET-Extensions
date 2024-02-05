namespace Extensions
{
    public static class intExtensions
    {
        private static string[] zeroToNineteen = [
            "",
            "one",
            "two",
            "three",
            "four",
            "five",
            "six",
            "seven",
            "eight",
            "nine",
            "ten", 
            "eleven",
            "twelve",
            "thirteen",
            "fourteen",
            "fifteen",
            "sixteen",
            "seventeen",
            "eighteen",
            "nineteen"
        ];

        private static string[] multiplesOfTen = [
            "",
            "ten",
            "twenty",
            "thirty",
            "forty",
            "fifty",
            "sixty",
            "seventy",
            "eighty",
            "ninety"
        ];

        public static string AsText(this int value, bool permitHundredsToTenThousand = false)
        {
            if (value == 0) return "zero";
            if (value == int.MinValue) return (int.MinValue + 1).AsText().TrimEnd([ 's', 'e', 'v', 'n' ]) + "eight";
            if (value < 0) return "negative " + AsTextInner(Math.Abs(value), permitHundredsToTenThousand);
            return AsTextInner(value, permitHundredsToTenThousand);
        }

        private static string AsTextInner(int value, bool permitHundredsToTenThousand = false)
        {
            if (value == 0) return string.Empty;
            if (value < 0) return "negative " + AsTextInner(Math.Abs(value), permitHundredsToTenThousand);
            if (value.InRange(0, zeroToNineteen.Length - 1)) return zeroToNineteen[value];
            if (value <= 99) return multiplesOfTen[value / 10] + ("-" + AsTextInner(value % 10, permitHundredsToTenThousand)).TrimEnd('-');
            if (value <= 999 || (permitHundredsToTenThousand && value <= 9_999 && (value / 100) % 10 != 0)) return AsTextInner(value / 100, permitHundredsToTenThousand) + (" hundred " + AsTextInner(value % 100, permitHundredsToTenThousand)).TrimEnd();
            if (value <= 999_999) return AsTextInner(value / 1_000, permitHundredsToTenThousand).TrimEnd() + (" thousand " + AsTextInner(value % 1_000, permitHundredsToTenThousand)).TrimEnd();
            if (value <= 999_999_999) return AsTextInner(value / 1_000_000, permitHundredsToTenThousand).TrimEnd() + (" million " + AsTextInner(value % 1_000_000, permitHundredsToTenThousand)).TrimEnd();
            return AsTextInner(value / 1_000_000_000, permitHundredsToTenThousand).TrimEnd() + (" billion " + AsTextInner(value % 1_000_000_000, permitHundredsToTenThousand)).TrimEnd();
        }

        public static string AsOrdinal(this int value)
        {
            if (value == int.MinValue) return value.ToString("N0") + "th";
            if (value < 0) return "-" + Math.Abs(value).AsOrdinal();

            var numberStr = value.ToString("N0");
            if ((value % 100).InRange(11, 13)) return numberStr + "th";

            switch (value % 10)
            {
                case 1: return numberStr + "st";
                case 2: return numberStr + "nd";
                case 3: return numberStr + "rd";
                default: return numberStr + "th";
            }
        }
    }
}
