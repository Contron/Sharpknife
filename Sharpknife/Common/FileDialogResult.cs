using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Common
{
	/// <summary>
	/// Represents a file dialog result.
	/// </summary>
	public class FileDialogResult<T>
	{
		/// <summary>
		/// Creates a new file dialog result.
		/// </summary>
		/// <param name="element">the element</param>
		/// <param name="succeeded">if the result succeeded</param>
		/// <param name="file">the file</param>
		/// <param name="exception">the exception</param>
		public FileDialogResult(T element, bool succeeded, string file, Exception exception)
		{
			this.Element = element;
			this.Succeeded = succeeded;
			this.File = file;
			this.Exception = exception;
		}

		/// <summary>
		/// Creates a new successful file dialog result.
		/// </summary>
		/// <param name="element">the element</param>
		/// <param name="file">the file</param>
		public FileDialogResult(T element, string file) : this(element, true, file, null)
		{

		}

		/// <summary>
		/// Creates a new unsuccessful file dialog result.
		/// </summary>
		/// <param name="exception">the exception</param>
		public FileDialogResult(Exception exception) : this(default(T), false, null, exception)
		{

		}

		/// <summary>
		/// Creates a new empty file dialog result.
		/// </summary>
		public FileDialogResult() : this(default(T), false, null, null)
		{

		}

		/// <summary>
		/// The element for the result.
		/// </summary>
		public T Element
		{
			get;
			set;
		}

		/// <summary>
		/// If the result succeeded.
		/// </summary>
		public bool Succeeded
		{
			get;
			set;
		}

		/// <summary>
		/// The file for the result.
		/// </summary>
		public string File
		{
			get;
			set;
		}

		/// <summary>
		/// The exception for the result.
		/// </summary>
		public Exception Exception
		{
			get;
			set;
		}
	}
}
