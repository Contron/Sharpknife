using System;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// Provides a collection of methods to work with <see cref="DateTime" /> instances.
	/// </summary>
	public static class Dates
	{
		/// <summary>
		/// Returns the estimated time ago for the specified date.
		/// </summary>
		/// <param name="date">the date</param>
		/// <returns>the time ago</returns>
		public static string GetTimeAgo(DateTime date)
		{
			var span = new TimeSpan(DateTime.Now.Ticks - date.Ticks);
			var delta = Math.Abs(span.TotalSeconds);

			if (delta < 60)
			{
				return $"{span.Seconds} seconds ago";
			}

			if (delta < 3600)
			{
				return $"{span.Minutes} minutes ago";
			}

			if (delta < 86400)
			{
				return $"{span.Hours} hours ago";
			}

			if (delta < 604800)
			{
				return $"{span.Days} days ago";
			}

			if (delta < 2592000)
			{
				return $"{Math.Max(span.Days / 7, 1)} weeks ago";
			}

			if (delta < 31622400)
			{
				return $"{Math.Max(span.Days / 30, 1)} months ago";
			}

			return  $"{Math.Max(span.Days / 365, 1)} years ago";
		}
	}
}
