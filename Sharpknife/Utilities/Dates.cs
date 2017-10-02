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
				return span.Seconds == 1 ? "One second ago" : $"{span.Seconds} seconds ago";
			}

			if (delta < 3600)
			{
				return span.Minutes == 1 ? "one minute ago" : $"{span.Minutes} minutes ago";
			}

			if (delta < 86400)
			{
				return span.Hours == 1 ? "one hour ago" : $"{span.Hours} hours ago";
			}

			if (delta < 604800)
			{
				return span.Days == 1 ? "yesterday" : $"{span.Days} days ago";
			}

			if (delta < 2592000)
			{
				var weeks = Math.Max(span.Days / 7, 1);

				return weeks == 1 ? "one week ago" : $"{weeks} weeks ago";
			}

			if (delta < 31622400)
			{
				var months = Math.Max(span.Days / 30, 1);

				return months == 1 ? "one month ago" : $"{months} months ago";
			}

			var years = Math.Max(span.Days / 365, 1);

			return years == 1 ? "one year ago" : $"{years} years ago";
		}
	}
}
