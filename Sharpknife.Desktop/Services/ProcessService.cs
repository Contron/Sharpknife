using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Desktop.Services
{
	/// <summary>
	/// Represents a process service to launch external processes.
	/// </summary>
	public sealed class ProcessService
	{
		private ProcessService()
		{

		}

		/// <summary>
		/// Launches the process at the specified path.
		/// </summary>
		/// <param name="path">the path</param>
		public void Start(string path)
		{
			if (path == null)
			{
				throw new ArgumentNullException(nameof(path));
			}

			Process.Start(path);
		}

		/// <summary>
		/// Gets the instance of the process service.
		/// </summary>
		public static ProcessService Instance => ProcessService.instance;

		private static readonly ProcessService instance = new ProcessService();
	}
}
