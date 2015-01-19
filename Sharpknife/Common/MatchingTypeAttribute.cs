using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpknife.Common
{
	/// <summary>
	/// Represents an attribute that can be used to match an appropriate type to anything.
	/// This is most useful for enums that require an association with a specified type.
	/// </summary>
	[AttributeUsage(AttributeTargets.All)]
	public class MatchingTypeAttribute : Attribute
	{
		/// <summary>
		/// Creates a new matching type attribute.
		/// </summary>
		/// <param name="type">the type</param>
		public MatchingTypeAttribute(Type type)
		{
			this.Type = type;
		}

		/// <summary>
		/// The actual type for the matching type.
		/// </summary>
		public Type Type
		{
			get;
			private set;
		}
	}
}
