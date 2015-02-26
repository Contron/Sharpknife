using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife
{
	/// <summary>
	/// The main class for Sharpknife.
	/// </summary>
    public class Sharpknife
    {
		/// <summary>
		/// Gets the current application path.
		/// </summary>
		public static string ApplicationPath
		{
			get
			{
				//folders
				var folder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
				var assembly = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
				var path = Path.Combine(folder, assembly);

				return path;
			}
		}
    }
}
