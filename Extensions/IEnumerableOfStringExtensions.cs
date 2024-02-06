namespace Extensions
{
	public static class IEnumerableOfStringExtensions
	{
		public static string Join(this IEnumerable<string> source, string separator) => string.Join(separator, source);

		public static string TextualJoin(this IEnumerable<string> items, string conjunction = "and", bool complexItems = false)
		{
			ArgumentNullException.ThrowIfNull(items);
			items = items.Select((item) =>
			{
				ArgumentNullException.ThrowIfNull(item, nameof(items));
				ArgumentException.ThrowIfNullOrWhiteSpace(item, nameof(items));
				return item.Trim();
			});

			ArgumentNullException.ThrowIfNull(conjunction);
			ArgumentException.ThrowIfNullOrWhiteSpace(conjunction);
			conjunction = conjunction.Trim();

			var joiner = complexItems ? "; " : ", ";
			switch (items.Count())
			{
				case 0: return string.Empty;
				case 1: return items.Single();
				case 2: return items.First() + " " + conjunction + " " + items.Last();
				default: return string.Join(joiner, items.SkipLast(1)) + joiner + conjunction + " " + items.Last();
			}
		}
	}
}
