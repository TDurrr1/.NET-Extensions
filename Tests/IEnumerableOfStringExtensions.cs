using Extensions;

namespace Tests
{
	public class IEnumerableOfStringExtensions
	{
		[Theory]
		[InlineData(",", "")]
		[InlineData(",", "a", "a")]
		[InlineData("*", "a*b", "a", "b")]
		[InlineData(" ", "a b c", "a", "b", "c")]
		[InlineData("", "abc", "a", "b", "c")]
		public void Join(string separator, string expected, params string[] values)
		{
			Assert.Equal(expected, values.Join(separator));
		}

		[Theory]
		[InlineData("", "and", false)]
		[InlineData("c", "and", false, "c")]
		[InlineData("a or b", "or", false, "a", "b")]
		[InlineData("d, e, and even f", "and even", false, "d", "e", "f")]
		[InlineData("d; e; f; g; and even h", "and even", true, "d", "e", "f", "g", "h")]
		public void TextualJoin(string expected, string conjunction, bool complex, params string[] values)
		{
			Assert.Equal(expected, values.TextualJoin(conjunction, complex));
		}
	}
}