using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Utilities
{
	/// <summary>
	/// A collection of WMI methods.
	/// </summary>
	public static class Wmi
	{
		/// <summary>
		/// Performs a query on the specified table.
		/// </summary>
		/// <param name="table">the table</param>
		/// <returns>the results</returns>
		public static List<Dictionary<string, object>> Query(string table)
		{
			var results = new List<Dictionary<string, object>>();
			var query = new SelectQuery(string.Format("SELECT * FROM {0}", table));

			using (var searcher = new ManagementObjectSearcher(query))
			{
				var collection = searcher.Get();

				foreach (var item in collection)
				{
					var dictionary = new Dictionary<string, object>();

					foreach (var property in item.Properties)
					{
						dictionary[property.Name] = item[property.Name];
					}

					results.Add(dictionary);
				}
			}

			return results;
		}
	}
}
