namespace Sharpknife.Utilities
{
	/// <summary>
	/// Provides a collection of methods to work with numbers.
	/// </summary>
	public static class Numbers
	{
		/// <summary>
		/// Returns the ordinal (st, nd, rd) suffix for the specified number.
		/// </summary>
		/// <param name="number">the number</param>
		/// <returns></returns>
		public static string GetOrdinal(int number)
		{
			var ones = number % 10;
			var tens = (number / 10) % 10;

			if (tens != 1)
			{
				switch (ones)
				{
					case 1:
					{
						return $"{number}st";
					}
					case 2:
					{
						return $"{number}nd";
					}
					case 3:
					{
						return $"{number}rd";
					}
					default:
					{
						break;
					}
				}
			}

			return $"{number}th";
		}
	}
}
