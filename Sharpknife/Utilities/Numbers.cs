using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
						return "st";
					}
					case 2:
					{
						return "nd";
					}
					case 3:
					{
						return "rd";
					}
					default:
					{
						break;
					}
				}
			}

			return "th";
		}
	}
}
