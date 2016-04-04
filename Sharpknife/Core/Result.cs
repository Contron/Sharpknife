using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Core
{
	/// <summary>
	/// Represents the result of a particular action that contains either the resulting object instance, or an <see cref="System.Exception" />.
	/// </summary>
	/// <typeparam name="T">the type</typeparam>
	public class Result<T> where T : class
	{
		/// <summary>
		/// Creates a new successful result with the specified instance.
		/// </summary>
		/// <param name="instance">the instance</param>
		public Result(T instance)
		{
			if (instance == null)
			{
				throw new ArgumentNullException(nameof(instance));
			}

			this.Instance = instance;
			this.Exception = null;
		}

		/// <summary>
		/// Creates a new unsuccessful result with the specified exception.
		/// </summary>
		/// <param name="exception">the exception</param>
		public Result(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException(nameof(exception));
			}

			this.Instance = null;
			this.Exception = exception;
		}

		/// <summary>
		/// Creates a new unsuccessful result.
		/// </summary>
		public Result()
		{
			this.Instance = null;
			this.Exception = null;
		}

		/// <summary>
		/// Returns a string representation of the result.
		/// </summary>
		/// <returns>the result</returns>
		public override string ToString()
		{
			return $"Result (Instance: {this.Instance}, Exception: {this.Exception})";
		}

		/// <summary>
		/// Gets the instance.
		/// </summary>
		public T Instance
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets the exception.
		/// </summary>
		public Exception Exception
		{
			get;
			private set;
		}

		/// <summary>
		/// Gets if the result was successful.
		/// </summary>
		public bool Successful
		{
			get
			{
				return this.Instance != null && this.Exception == null;
			}
		}

		/// <summary>
		/// Gets if the result threw an exception.
		/// </summary>
		public bool Errored
		{
			get
			{
				return this.Exception != null;
			}
		}
	}
}
